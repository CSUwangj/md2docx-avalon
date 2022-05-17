# MD2DocxAvalon (WIP)

A GUI program that can convert markdown into docx with user defined configuration.

For Central South University students, it can auto generate cover, table of content, footer, header, etc. Can be very useful
especially when they are graduating bachelor students or are writing experimental report.

## Install

### download from nightly build

1. go to <https://github.com/CSUwangj/md2docx-avalon/actions/workflows/build.yml>
2. find a success build and click it
3. find artifacts at the bottom of the page
4. download

### build from source

``` powershell
dotnet restore
dotnet build
```

## Progress

- [X] basic GUI
- [X] convert markdown into docx file
- [X] yaml header parse
- [X] CSU specific feature
  - [X] cover
  - [X] TOC
  - [X] header
  - [X] footer
- [X] image
- [X] footnote & references
- [X] list
- [ ] link
- [ ] features may not implement
  - [ ] math formula
  - [ ] table
  - [ ] package, publish, install
  - [ ] configuration memorize
- [ ] feature won't implement
  - [ ] quote