﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// Copied from: https://github.com/dotnet/sdk/blob/4a81a96a9f1bd661592975c8269e078f6e3f18c9/src/Cli/Microsoft.DotNet.Cli.Utils/IEnvironmentProvider.cs
namespace Azure.Functions.Cli.Abstractions.Environment
{
    public interface IEnvironmentProvider
    {
        IEnumerable<string> ExecutableExtensions { get; }

        string? GetCommandPath(string commandName, params string[] extensions);

        string? GetCommandPathFromRootPath(string rootPath, string commandName, params string[] extensions);

        string? GetCommandPathFromRootPath(string rootPath, string commandName, IEnumerable<string> extensions);

        bool GetEnvironmentVariableAsBool(string name, bool defaultValue);

        int? GetEnvironmentVariableAsNullableInt(string name);

        string? GetEnvironmentVariable(string name);

        string? GetEnvironmentVariable(string variable, EnvironmentVariableTarget target);

        void SetEnvironmentVariable(string variable, string value, EnvironmentVariableTarget target);
    }
}
