version: 1.0.{build}

os: Visual Studio 2015 RC

# config folder
pushd %cd%
cd %userprofile%\.dnx\runtimes\dnx*\bin
set path=%path%;%cd%
popd

# restore and build web project
cmd /c dnu restore
cmd /c dnu build web

# execute tests
# cmd /c dnu build Tests --configuration Release
# cmd /c dnx Tests test

# starting app in docker
# choco install docker -y
# set docker_host=tcp://tbr.cloudapp.net:2375
# docker build -t api Api
# docker run -t -d -p 5004:5004 api