# COVID19 Data Visualization with HoloLens2 + MRTK
Experimental COVID-19 Data Visualization for HoloLens 2 with MRTK. This project explores how volumetric data can be represented in physical space with direct hand-tracking inputs in mixed reality using HoloLens 2. It is based on Microsoft's [MRTK(Microsoft's Mixed Reality Toolkit)](https://github.com/microsoft/MixedRealityToolkit-Unity)<br/> The project works with HoloLens 1st gen as well. (use static menu instead of hand menu)<br/>

![20200330_231204_HoloLens](https://user-images.githubusercontent.com/13754172/78055611-a31a6400-7338-11ea-82e2-05987de9feeb.jpg)
![COVID_HL2_0405B](https://user-images.githubusercontent.com/13754172/78509640-51ad1300-7744-11ea-8603-1e2d446f76d3.gif)

## Video (Updated 4/5/2020)
https://youtu.be/mN7VM2h41_w

## App for HoloLens 1st gen and HoloLens 2
**Now you can download the app from Microsoft Store in your HoloLens 1 and HoloLens 2.**
Due to Microsoft Store's policy, you need to directly type in this URL in the Edge browser to open Store page and download the app.
URL: **https://cutt.ly/covid19mr**
The app title is 'COVID-19 Data Visualization'

## Data source
ESRI's Coronavirus COVID-19 Cases feature layer<br/>
https://coronavirus-resources.esri.com/datasets/bbb2e4f589ba40d692fab712ae37b9ac

## Project
**DataVisualizer.cs** script contains the code for retrieving, parsing JSON data, and visualizing with graphs. Graph elements are added to GraphContainerConfirmed, GraphContainerRecovered, GraphContainerFatal, and LabelContainer. CreateMeshes() creates the graph for three data values and text label. Main menu's Radio buttons simply show/hide GraphContainer objects.
![2020-04-05 18_26_25-COVIDDataVizGit - Microsoft Visual Studio](https://user-images.githubusercontent.com/13754172/78515520-065a2b00-776b-11ea-9655-f24c18cbbc74.png)


<br/><br/>
Menu stays around the user with tag-along behavior which is provided by MRTK's RadialView solver. Using the pin button, you can toggle tag-along behavior. Menu's backplate can be grabbed and moved. Grabbing and moving menu automatically disables the tag-along and makes the menu world-locked. 

Menu's toggle button shows & hides GraphContainer and LabelContainer. 
Use slider UI for configuring the earth rendering options.
- Earth color saturation level
- Cloud opacity
- Sea color saturation level
<br/><br/>
<img src="https://user-images.githubusercontent.com/13754172/78515560-27bb1700-776b-11ea-90d8-1f8bf6015f4b.png" width="500px">


![2020-03-31 09_58_03-Unity 2018 4 12f1 Personal - COVID19HoloLens2 unity - COVIDDataVizGit - PC, Mac ](https://user-images.githubusercontent.com/13754172/78075949-4cbe1d00-735a-11ea-89bd-7192651ee959.png)
![2020-04-05 11_22_36-Unity 2018 4 12f1 Personal - COVID19HoloLens2 unity - COVIDDataVizGit - Universa](https://user-images.githubusercontent.com/13754172/78507729-a77abe80-7736-11ea-85c4-50d2c12bb48b.png)

## Build and deploy
Please make sure to use 'Single Pass' (not Single Pass Instanced) to render graph properly on the device.
![2020-04-02 21_46_58-Unity 2018 4 12f1 Personal - COVID19HoloLens2 unity - COVIDDataVizGit - Universa](https://user-images.githubusercontent.com/13754172/78325429-644cff80-752c-11ea-88db-c9102c5f3528.png)

## Built with these open-source components
- MRTK(Mixed Reality Toolkit) (http://aka.ms/MRTK)
- Unity3DGlobe (https://github.com/Dandarawy/Unity3D-Globe)
- Moon and Earth (https://github.com/keijiro/MoonAndEarth)
- SimpleJSON (https://github.com/Bunny83/SimpleJSON)

## Features
- Near interactions with direct grab/move/rotate (one or two-handed)
- Far interactions using hand ray (one or two-handed)
- Main menu to switch the data, change earth rendering options
- Toggle graph, text label
- Toggle auto-rotate 

## Known issues
- Data normalization & polish needed
- Sometimes two-handed manipulation makes the globe tiny and not properly scalable. Use hand-ray to make it bigger again.

![MadeWithMRTK_1920x](https://user-images.githubusercontent.com/13754172/78519812-47f1d280-7779-11ea-9fdd-7bbdb7b4f9f5.png)

