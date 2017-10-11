# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [3.3.0-beta1]

### Added
 - Support .NET Standard 2.0

### Removed
 - .NET 3.5, .NET 4.0 and Silverlight
 - Dropped support for NLog1 NLog2 NLog3

## [3.2.3]

### Added
- Support NLog4.

## [3.2.2]

### Added
- Support Serilog.
- Support NLog3.

## [3.2.1]

### Changed
- loggers by name or type will not be cached in dictionaroes.

## [3.0.1]

### Added
- non string format message logging methods to the interface and implemented them in all implementations

## [3.0.0.0]

### Removed
- No web builds. All builds are have not reference to web anymore.
