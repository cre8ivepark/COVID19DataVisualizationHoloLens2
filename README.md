# COVID19 Data Visualization with HoloLens2 + MRTK
Experimental COVID-19 Data Visualization for HoloLens 2 with MRTK. This project explores how volumetric data can be represented in physical space with direct hand-tracking inputs in mixed reality using HoloLens 2. It is based on Microsoft's [MRTK(Microsoft's Mixed Reality Toolkit)](https://github.com/microsoft/MixedRealityToolkit-Unity)<br/> The project works with HoloLens 1st gen as well. (use static menu instead of hand menu)<br/>

![20200330_231204_HoloLens](https://user-images.githubusercontent.com/13754172/78055611-a31a6400-7338-11ea-82e2-05987de9feeb.jpg)

## Video
https://youtu.be/rCNq40mOZ64

## App package for HoloLens 2 (ARM) and HoloLens 1st gen (x86)
Download in Release page
https://github.com/cre8ivepark/COVID19DataVisualizationHoloLens2/releases/tag/0.1

## Data source
ESRI's Coronavirus COVID-19 Cases feature layer<br/>
https://coronavirus-resources.esri.com/datasets/bbb2e4f589ba40d692fab712ae37b9ac

## Project
Data Visualizer script contains the code for retrieving, parsing JSON data, and visualizing with graphs. Graph elements are added to GraphContainer and LabelContainer. CreateMeshes(int dataType) simply uses confirmed cases(0), recovered cases(1), fatal cases(2) to visualize specific data. Hand menu's Radio buttons calls CreateMeshes(0), CreateMeshes(1), CreateMeshes(2).
![2020-03-31 14_15_39-COVID19Visualizer4 - Microsoft Visual Studio](https://user-images.githubusercontent.com/13754172/78075917-3fa12e00-735a-11ea-9dad-4c92f2d81a80.png)
<br/><br/>
Hand menu's toggle button shows & hides GraphContainer and LabelContainer. <br/>
![2020-03-31 09_27_37-Unity 2018 4 12f1 Personal - COVID19HoloLens2 unity - COVIDDataVizGit - PC, Mac ](https://user-images.githubusercontent.com/13754172/78075934-44fe7880-735a-11ea-9309-3a34aa4c4666.png)
![2020-03-31 09_58_03-Unity 2018 4 12f1 Personal - COVID19HoloLens2 unity - COVIDDataVizGit - PC, Mac ](https://user-images.githubusercontent.com/13754172/78075949-4cbe1d00-735a-11ea-89bd-7192651ee959.png)
![2020-03-31 09_26_53-Unity 2018 4 12f1 Personal - COVID19HoloLens2 unity - COVIDDataVizGit - PC, Mac ](https://user-images.githubusercontent.com/13754172/78075958-5051a400-735a-11ea-85eb-84486f166dd4.png)


## Built with these open-source components
- MRTK(Mixed Reality Toolkit) (http://aka.ms/MRTK)
- Unity3DGlobe (https://github.com/Dandarawy/Unity3D-Globe)
- Moon and Earth (https://github.com/keijiro/MoonAndEarth)
- SimpleJSON (https://github.com/Bunny83/SimpleJSON)

## Features
- Near interactions with direct grab/move/rotate (one or two-handed)
- Far interactions using hand ray (one or two-handed)
- Use hand menu to switch the data
- Toggle graph, text label

## Known issues
- There is flicker on data switching. Needs improvement on data retrieving
- Data normalization & polish needed
- Auto rotation is disabled. Graph orientation is distorted when the object is rotated.
