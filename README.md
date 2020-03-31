# COVID19 Data Visualization with HoloLens2 + MRTK
Experimental COVID-19 Data Visualization for HoloLens 2 with MRTK
![20200330_231204_HoloLens](https://user-images.githubusercontent.com/13754172/78055611-a31a6400-7338-11ea-82e2-05987de9feeb.jpg)

## Video
https://youtu.be/rCNq40mOZ64

## App package for HoloLens 2 (ARM)
Download in Release page
https://github.com/cre8ivepark/COVID19DataVisualizationHoloLens2/releases/tag/0.1

## Data source
ESRI's Coronavirus COVID-19 Cases feature layer

https://coronavirus-resources.esri.com/datasets/bbb2e4f589ba40d692fab712ae37b9ac

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
