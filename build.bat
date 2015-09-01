@powershell -NoProfile -ExecutionPolicy unrestricted -Command "&{$Branch='dev';iex ((new-object net.webclient).DownloadString('https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.ps1'))}"
cmd /c %userprofile%\.dnx\bin\dnvm install latest
pushd %cd%
cd %userprofile%\.dnx\runtimes\dnx*\bin
set path=%path%;%cd%
popd

cmd /c dnu restore
cmd /c dnu build web