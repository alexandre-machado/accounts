pushd %cd%
cd %userprofile%\.dnx\runtimes\dnx*\bin
set path=%path%;%cd%
popd

cmd /c dnu restore
cmd /c dnu build web