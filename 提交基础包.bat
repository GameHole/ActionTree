@echo off
cd %~dp0
git subtree split --prefix=Assets/ActionTree --branch ump_basic
git tag 1.0.0 ump_basic
git push origin ump_basic --tags
