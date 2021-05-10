@echo off
cd %~dp0
git subtree split --prefix=Assets/Common --branch ump_common
git tag common.1.0.0 ump_common
git push origin ump_common --tags
