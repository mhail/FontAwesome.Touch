module Fake.XamarinHelper

// Source: https://raw.githubusercontent.com/xamarin/xamarin-store-app/master/tools/XamarinHelper.fsx

open System
open System.IO

open Fake.FileUtils
open Fake.ProcessHelper

exception Exited of int

// Convenience function for running external commands
let sh command args =
    let result =
        ExecProcess (fun info ->
            info.FileName <- command
            info.Arguments <- args
        ) TimeSpan.MaxValue

    if result <> 0 then raise (Exited result)

let RestoreComponents (solution: string) =
    mkdir "tools/xpkg"
    if not <| File.Exists "tools/xpkg/xamarin-component.exe" then
        sh "curl" "-o xpkg.zip https://components.xamarin.com/submit/xpkg"

        // unzip annoyingly returns 1 on success, so we have to catch that
        try
            sh "unzip" "xpkg.zip -d tools/xpkg"
        with Exited 1 -> ()

        rm "xpkg.zip"
    sh "tools/xpkg/xamarin-component.exe" (sprintf "restore %s" solution)

let BuildiOSPackage (project: string, config: string) =
    sprintf "build %s --configuration:'%s'" project config
    |> sh "/Applications/Xamarin Studio.app/Contents/MacOS/mdtool"

let BuildAndroidPackage (project: string) =
    project
    |> sprintf "%s /property:Configuration=Release /target:SignAndroidPackage"
    |> sh "xbuild"
