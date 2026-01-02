# vCard File Splitter

[![License: MIT](https://img.shields.io/badge/License-MIT-red.svg)](LICENSE.txt)
[![Build and Create Release](https://github.com/paoldev/vCardFileSplitter/actions/workflows/dotnet_create_release.yml/badge.svg)](https://github.com/paoldev/vCardFileSplitter/releases)

vCard File Splitter (c) 2023-2026 paoldev  
  
Split or merge vcf and vCard files without applying any further processing to original file lines.  
  
This application requires the [.NET 10.0 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/10.0); it can be automatically downloaded and installed on the application's first run.  
  
This source code implementation is not intended to fulfill [RFC 6350: vCard Format Specification](https://www.rfc-editor.org/rfc/rfc6350); it just shows a vCard preview, with few properties, since its solely scope is to split a single 'multiple vCards' file into separated files or to merge them into a single file.  
  
I wrote this application to split my phone `AddressBook.vcf` file into separated contacts' files, to share them with other applications.

# License

This project is licensed under the terms of the [MIT license](./LICENSE.txt).
