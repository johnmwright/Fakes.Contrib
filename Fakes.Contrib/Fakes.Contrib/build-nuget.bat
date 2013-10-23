@echo off
del *.nupkg
nuget pack -Build -Properties Configuration=Release