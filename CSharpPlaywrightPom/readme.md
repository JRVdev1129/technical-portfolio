# DOTNET Playwright

### Test Coverage

- [internet Tests](./tests/TheInternetSpec/)
  - Test type: E2E

## Local setup instructions

[Download And Install .Net SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

Install Playwright for C#

1. Install the Playwright tool with the next command

```console
  dotnet tool install --global Microsoft.Playwright.CLI
```

2. Build Project

```console
   dotnet build
```

3. Install Playwright. Run this command inside the project directory.(If you are running this outside of windows you will need to have [powershell](https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell?view=powershell-7.4) installed)

```console
   pwsh bin/Debug/net8.0/playwright.ps1 install
```

## Run tests

You can run the test with the following command

```console
    dotnet test -s firefox.runsettings
```

To run a specific test you can use the --filter flag

```console
    dotnet test --filter "abTest"
```

For get the list of filter: https://docs.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests?pivots=nunit
