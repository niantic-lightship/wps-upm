## Name
wps-upm

## Description
The (World Positioning System) WPS UPM is the Unity package needed in order to use the World Positioning System features from Lightship ARDK in your Unity application. This file can be be brought into your project by using the Unity Package Manager. You can install the WPS UPM package via a git URL, or from a Tarball (`.tgz`) file. Detailed steps to install the WPS UPM can be found in our [developer documentation for Installing the ARDK Plugin](https://lightship.dev/docs/ardk/setup/#installing-the-ardk-plugin-with-a-url). These steps are also noted below:

### Installing the World Positioning System Plugin with a URL
0. A prerequisite to using the WPS UPM is having the ARDK UPM installed. For more information on installing the ARDK UPM to your project, please see the [ardk-upm ReadMe file](https://github.com/niantic-lightship/ardk-upm/blob/main/README.md). 
1. In your Unity project open the **Package Manager** by selection **Window > Package Manager**. 
	- From the plus menu on the Package Manager tab, select **Add package from git URL...**
	- Enter `https://github.com/niantic-lightship/wps-upm.git`. 

### Installing the World Positioning System Plugin from Tarball
0. A prerequisite to using the WPS UPM is having the ARDK UPM installed. For more information on installing the ARDK UPM to your project, please see the [ardk-upm ReadMe file](https://github.com/niantic-lightship/ardk-upm/blob/main/README.md). 
1. Download the plugin packages (`.tgz`) from the latest release
	- [wps-upm](https://github.com/niantic-lightship/wps-upm/releases/latest)
2. In your Unity project open the **Package Manager** by selection **Window > Package Manager**. 
	- From the plus menu on the Package Manager tab, select **Add package from tarball...**
	- Navigate to where you downloaded the WPS UPM, select the `.tgz` file you downloaded, and press **Open**. This will install the package in your project's **Packages** folder as the **World Positioning System Plugin** folder. 
	- Click **Yes** to activate the new Input System Package for AR Foundation 5.0 (if prompted). 

## More Information on World Positioning System
- [World Positioning System How-To Guide](https://lightship.dev/docs/ardk/how-to/ar/world_pose/)

## Support
For any other issues, [contact us](https://lightship.dev/docs/ardk/contact_us/) on Discord or the Lightship forums! Before reaching out, open the Console Log by holding three touches on your device's screen for three seconds, then take a screenshot and post it along with a description of your issue.
