# FileProcessingSolution

FileProcessingSolution is an application developed in .NET Core designed for efficient and modular file processing. It includes a main library, `FileProcessingLib`, and a set of unit tests, `FileProcessingLib.Tests`, ensuring reliability and robustness of its features.

## Key Features

- **CSV File Processing**: Enables the import, cleaning, and transformation of data in CSV format.
- **Modular Architecture**: Based on a flexible design for simplified extensibility and maintenance.
- **Unit Testing**: Covers core functionalities with automated tests to ensure code quality.

## Project Structure

- `FileProcessingLib`: Contains the core components for file processing, including classes and services.
- `FileProcessingLib.Tests`: Includes unit tests to validate the functionalities of the main library.

## Prerequisites

- **.NET 6.0**: The solution is compatible with .NET Core version 6.0.
- **Development Tools**: Visual Studio 2022

## Installation

1. Clone the GitHub repository:
   ```bash
   git clone https://github.com/your-username/FileProcessingSolution.git
   ```
2. Navigate to the project directory:
   ```bash
   cd FileProcessingSolution
   ```
3. Restore NuGet packages:
   ```bash
   dotnet restore
   ```

## Usage

### Processing Example
Here is an example of using `FileProcessingLib` to process a CSV file:

```csharp
using FileProcessingLib;

var processor = new CsvFileProcessor();
processor.Process("path/to/file.csv");
```

### Running Tests
To run unit tests:
```bash
dotnet test
```


## License

This project is licensed under the MIT License. See the LICENSE file for more details.

