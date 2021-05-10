@echo off
cd %~dp0
git tag -d common.1.0.0
git push origin :refs/tags/common.1.0.0
