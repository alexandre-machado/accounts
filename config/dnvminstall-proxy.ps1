&{
	$proxy = new-object System.Net.WebProxy;
	$proxy.Address = "cache.lojasrenner.com.br:3128" #Read-Host "Proxy Address?";
	$user = Read-Host "User?";
	$pwd = Read-Host "Password?" -assecurestring;
	$account = new-object System.Net.NetworkCredential(
		$user,
		[Runtime.InteropServices.Marshal]::PtrToStringAuto([Runtime.InteropServices.Marshal]::SecureStringToBSTR($pwd)),
		"");
	$Branch='dev';
	$wc = New-Object System.Net.WebClient;
	$wc.Proxy = [System.Net.WebRequest]::DefaultWebProxy;
	$wc.Proxy.Credentials = $account #[System.Net.CredentialCache]::DefaultNetworkCredentials;
	Invoke-Expression ($wc.DownloadString('https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.ps1'))
}
