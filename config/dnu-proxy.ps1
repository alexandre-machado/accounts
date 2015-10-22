$source = @"
<configuration>
  <system.net>
    <defaultProxy useDefaultCredentials="true" enabled="true">
      <proxy usesystemdefault="True"/>
    </defaultProxy>
  </system.net>
</configuration>
"@

Get-ChildItem "~\.dnx\runtimes" -Recurse -Force -Filter "dnx.exe" | 
    %{ $_.DirectoryName } |
    Get-Unique |
    ForEach { $source >> "$_\dnx.exe.config" }