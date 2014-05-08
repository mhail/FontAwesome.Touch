#!/bin/bash
if [ ! -f tools/FAKE/tools/Fake.exe ]; then
  mono --runtime=v4.0 tools/NuGet/nuget.exe install "FAKE" -Version "2.13.4" -OutputDirectory "tools" -ExcludeVersion
fi
mono --runtime=v4.0 tools/FAKE/tools/FAKE.exe build.fsx $@
