<!--
SPDX-FileCopyrightText: 2025 chronovore/legiayayana

SPDX-License-Identifier: MIT
-->

# Arm64Disassembler

A thin C# P/Invoke wrapper around Binary Ninja's Arm64 disassembler.

Personally find this to be faster and better than capstone.

## Attribution

Binary Ninja's Arm64 diassembler is licensed under Apache-2.0

https://github.com/Vector35/binaryninja-api/blob/dev/arch/arm64/LICENSE

## Building

Native modules can be built via [Meson](https://mesonbuild.com/Getting-meson.html).

```sh
mkdir build
cd build
meson setup .. --buildtype=release
meson compile
```

The disassembler is set up to load next to the assembly directory and the assembly runtime, some common ones:

- runtime/linux-x64/native/libbinjaarm64.so
- runtime/linux-arm64/native/libbinjaarm64.so
- runtime/win-x64/native/libbinjaarm64.dll
- runtime/mac-x64/native/libbinjaarm64.dylib
- runtime/mac-arm64/native/libbinjaarm64.dylib

and other [RIDs](https://learn.microsoft.com/en-us/dotnet/core/rid-catalog#known-rids).

Copy the shared library to the correct path.
