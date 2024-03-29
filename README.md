# PMP-118

This project utilizes several FeatureFlag providers. The following providers are utilized:

* FeatureFlow.io - https://shireburn.featureflow.io
* Rollout - https://app.rollout.io/
* Split.io - https://app.split.io/login
* Optimizely - https://app.optimizely.com
* LaunchDarkly - https://app.launchdarkly.com

Credentials can be found in the corresponding Jira ticket

- - - -

## Requirements

**Needs**
* N1 - Enable/Disable a feature for a percentage of our users (Canary Releases)
* N2 - Enable/Disable a feature for a particular tenant/tenants
* N3 - Enable/Disable a feature fpr a group of tenants
* N4 - Disabling a feature if an issue is encountered
* N5 - Supports minimum JS, .NET Framework
- - - -
**Shoulds**
* S1 - Statistics on unused feature flags
* S2 - Statistics on feature flags which have been turned on the last x days/months
* S3 - Statistics on how many times the feature has been accessed and maybe by whom
- - - -
**Ease of Use**
* E1 - Ease of use for non-technical users
* E2 - Ease of use for technical users (Complexity of SDK)

- - - -

The following charts compares each provider against the requirements

![picture alt](https://github.com/TheReaLee/PMP-118/blob/master/PMP-118.png "Feature Flag Providers")

**The following ratings can be biased, I therefore suggest that you navigate through the provider's websites and decide for yourself**

![picture alt](https://github.com/TheReaLee/PMP-118/blob/master/PMP-118-EaseOfUse.png "Feature Flag Providers - Ease of Use")

- - - -

## Using this repo

This project targets .NET Framework 4.5.2

**Packages**
- Featureflow 1.1.1
- Optimizely.SDK 3.2.0
- Splitio 5.0.0
- LaunchDarkly.ServerSdk 5.6.5
- rox-server 4.5.0

**Guide**
* Step 1 - Clone the repo
* Step 2 - Open Web.Config and Edit the Provider appSetting with one of the following values
  * Split
  * LaunchDarkly
  * FeatureFlow
  * Rollout
  * Optimizely
* Step 3 - Make sure that the Website is set as your startup project, and press F5
* Step 4 - A menu item named 'Costings' is configured as a feature flag
  * Log into the selected provider from the links above [Credentials found in PMP-118 ticket] and disable/enable the feature flag
* Step 5 - Refresh the browser and notice the 'Costings' menu item being shown/hidden

- - - -

## Conclusion

Rollout and FeatureFlow did not meet the **Needs** of the requirements thus are automatically excluded.

Furthermore after having tested out each of the providers above, I can suggest the following:
* **Free**: Optimizely or Split.io (Split.io having more statistical features)
* **Paid**: LaunchDarkly or Optimizely [Full Stack] (LaunchDarkly is easier to use and provides a better experience for rolling out features based on a set of conditions)
