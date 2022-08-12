![Release](https://img.shields.io/github/v/release/AN0NCER/steam-lib "Currect Version")
![Release](https://img.shields.io/github/repo-size/AN0NCER/steam-lib "Currect Version")

The library allows you to connect Steam Guard to your account, with the ability to have Steam Guard on multiple devices at the same time.

Library for:
  - NET Standart
  - NET Core
  - NET Framework

# Functionality
Currently, this library can [WIKI](https://github.com/AN0NCER/steam-lib/wiki):

* Generate login codes for a given Shared Secret
* Login to a user account
* Link and activate a new mobile authenticator to a user account after logging in
* Remove itself from an account
* Fetch, accept, and deny mobile confirmations

# Requirements

* [Newtonsoft.Json](http://www.newtonsoft.com/json)

# Usage
To generate login codes if you already have a Shared Secret, simply instantiate a `SteamGuardAccount` and set its `SharedSecret`. Then call `SteamGuardAccount.GenerateSteamGuardCode()`.

To add a mobile authenticator to a user, instantiate a `UserLogin` instance which will allow you to login to the account. After logging in, instantiate an `AuthenticatorLinker` and use `AuthenticatorLinker.AddAuthenticator()` and `AuthenticatorLinker.FinalizeAddAuthenticator()` to link a new authenticator. **After calling AddAuthenticator(), and before calling FinalizeAddAuthenticator(), please save a JSON string of the `AuthenticatorLinker.LinkedAccount`. This will contain everything you need to generate subsequent codes. Failing to do this will lock you out of your account.**

To fetch mobile confirmations, call `SteamGuardAccount.FetchConfirmations()`. You can then call `SteamGuardAccount.AcceptConfirmation` and `SteamGuardAccount.DenyConfirmation`.

More information in My [**WIKI**](https://github.com/MaximKolpak/steam-auth/wiki)
