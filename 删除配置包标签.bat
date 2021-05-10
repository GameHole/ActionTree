@echo off
cd %~dp0
git tag -d config.1.0.0
git push origin :refs/tags/config.1.0.0
