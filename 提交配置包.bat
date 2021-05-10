@echo off
cd %~dp0
git subtree split --prefix=Assets/CommonConfig --branch ump_config
git tag config.1.0.0 ump_config
git push origin ump_config --tags
