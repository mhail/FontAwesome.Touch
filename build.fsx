// include Fake lib
#I "tools/FAKE/tools"
#r @"FakeLib.dll"


open System
open System.IO

open Fake
open Fake.FileUtils
open Fake.ProcessHelper

#I "tools"
#load "XamarinHelper.fsx"

open Fake.XamarinHelper

exception Exited of int
let sh command args =
    let result =
        ExecProcess (fun info ->
            info.FileName <- command
            info.Arguments <- args
        ) TimeSpan.MaxValue

    if result <> 0 then raise (Exited result)

let buildDir = "build"
let packageDir = buildDir @@ "package"
let touchProjectDir = "." @@ "src" @@ "FontAwesome.Touch"

// Targets
Target "Clean" (fun _ ->
    CleanDirs [buildDir; (touchProjectDir @@ "bin"); (touchProjectDir @@ "obj")]
)

Target "BuildLib" (fun _->
  let proj = touchProjectDir @@ "FontAwesome.Touch.csproj"
  BuildiOSPackage (proj, "Release")

)

let version = "0.0.1"

Target "CreateNugetPackage" (fun _ ->
    let libDir = packageDir @@ "lib"
    CleanDirs [packageDir;libDir;]

    let dll = "FontAwesome.Touch.dll";

    CopyFile libDir (touchProjectDir @@ "bin" @@ "Release" @@ dll)

    let files = [
      (@"lib" @@ dll, Some ("lib" @@ "MonoTouch" @@ dll), None)
    ]

    NuGet(fun p ->
        {p with
            Authors = ["Matthew Hail"]
            Project = "FontAwesome.Touch"
            Description = "FontAwesome Component for Xamarin iOS"

            WorkingDir = packageDir
            OutputPath = packageDir

            Version = version
            Publish = false

            Files = files
        }) "template.nuspec"
)

Target "Default" DoNothing

"Clean"
==> "BuildLib"
==> "CreateNugetPackage"
==> "Default"

RunTargetOrDefault "Default"
