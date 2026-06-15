using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PasswordAnalyzer.Services;

public class PasswordBlacklistService
{
    private readonly HashSet<string> _breachedPasswords;

    public PasswordBlacklistService()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Data", "10k-most-common.txt");

        if (!File.Exists(path))
        {
            _breachedPasswords = new HashSet<string>();
            return;
        }

        _breachedPasswords = File.ReadAllLines(path)
            .Select(p => p.Trim().ToLowerInvariant())
            .Where(p => p.Length > 0)
            .ToHashSet();
    }

    public bool IsCommonPassword(string password)
    {
        return _breachedPasswords.Contains(password.Trim().ToLowerInvariant());
    }
}