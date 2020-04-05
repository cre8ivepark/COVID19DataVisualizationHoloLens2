using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using TMPro;
using System;

public class DataVisualizer : MonoBehaviour {
    public Material PointMaterial;
    public Gradient Colors;
    public GameObject GraphContainerConfirmed;
    public GameObject GraphContainerRecovered;
    public GameObject GraphContainerFatal;
    public GameObject LabelContainer;
    public GameObject Earth;
    public GameObject PointPrefab;
    public GameObject TextPrefab;

    public TextMeshPro tmpConfirmedTotal;
    public TextMeshPro tmpActiveTotal;
    public TextMeshPro tmpRecoveredTotal;
    public TextMeshPro tmpFatalTotal;
    public TextMeshPro tmpTimeStamp;

    private int nConfirmedTotal = 0;
    private int nActiveTotal = 0;
    private int nRecoveredTotal = 0;
    private int nFatalTotal = 0;

    public float ValueScaleMultiplier = 0.00002f;
    private JSONArray featuresArray;

    int currentSeries = 0;

    // Data point information from ESRI https://coronavirus-resources.esri.com/datasets/bbb2e4f589ba40d692fab712ae37b9ac?fbclid=IwAR0R2dlui4wQoCsyp1CPUYXpM2iOJAA0Zro4uJmUm5US3TsH8y2UqnZlplU
    private const string URL = "https://services1.arcgis.com/0MSEUqKaxRlEPj5g/ArcGIS/rest/services/Coronavirus_2019_nCoV_Cases/FeatureServer/1/query?where=1%3D1&objectIds=&time=&geometry=&geometryType=esriGeometryEnvelope&inSR=&spatialRel=esriSpatialRelIntersects&resultType=none&distance=0.0&units=esriSRUnit_Meter&returnGeodetic=false&outFields=*&returnGeometry=true&featureEncoding=esriDefault&multipatchOption=xyFootprint&maxAllowableOffset=&geometryPrecision=&outSR=&datumTransformation=&applyVCSProjection=false&returnIdsOnly=false&returnUniqueIdsOnly=false&returnCountOnly=false&returnExtentOnly=false&returnQueryGeometry=false&returnDistinctValues=false&cacheHint=false&orderByFields=&groupByFieldsForStatistics=&outStatistics=&having=&resultOffset=&resultRecordCount=&returnZ=false&returnM=false&returnExceededLimitFeatures=true&quantizationParameters=&sqlFormat=none&f=pjson&token=";
    public IEnumerator LoadJSONDataFromWeb()
    {
        WWW www = new WWW(URL);
        yield return www;

        // Extract token from parsed response
        var text = www.text.Replace(":null", ":\"\"");
        JSONNode N = JSON.Parse(text);

        //if (json.ContainsKey("error"))
        //{
        //    callback(null);
        //    yield break;
        //}
        featuresArray = N["features"].AsArray;

        CreateMeshes(); // Default start with Confirmed cases
    }

    // Use this for initialization
    void Start()
    {
        this.StartCoroutine(LoadJSONDataFromWeb());
    }

    public void ShowTextLabel()
    {

    }

    public void CreateMeshes()
    {
        nConfirmedTotal = 0;
        nActiveTotal = 0;
        nRecoveredTotal = 0;
        nFatalTotal = 0;
        
        GameObject p = Instantiate<GameObject>(PointPrefab);
        Vector3[] verts = p.GetComponent<MeshFilter>().mesh.vertices;
        int[] indices = p.GetComponent<MeshFilter>().mesh.triangles;

        List<Vector3> meshVertices = new List<Vector3>(65000);
        List<int> meshIndices = new List<int>(117000);
        List<Color> meshColors = new List<Color>(65000);

        long timestamp = 0;

        for (int i = 0; i < featuresArray.Count; i++)
        {
            GameObject seriesObj = new GameObject(featuresArray[i]["attributes"]["Province_State"].Value + "," + featuresArray[i]["attributes"]["Country_Region"].Value);
            seriesObj.transform.parent = GraphContainerConfirmed.transform;

            float lat = featuresArray[i]["attributes"]["Lat"].AsFloat;
            float lng = featuresArray[i]["attributes"]["Long_"].AsFloat;
            int n_confirmed = featuresArray[i]["attributes"]["Confirmed"].AsInt;
            int n_recovered = featuresArray[i]["attributes"]["Recovered"].AsInt;
            int n_deaths = featuresArray[i]["attributes"]["Deaths"].AsInt;

            string locationName;

            if (featuresArray[i]["attributes"]["Province_State"].Value != "null")
            {
                locationName = featuresArray[i]["attributes"]["Province_State"].Value; // + "," + featuresArray[i]["attributes"]["Country_Region"].Value + "  " + value;
            }
            else
            {
                locationName = featuresArray[i]["attributes"]["Country_Region"].Value; // + "  " + value;
            }

            //Debug.Log("**Lat/Long/Conf = " + lat + "/" + lng +"/"+ value + "/" + locationName);

            // Confirmed Cases
            AppendPointVertices(p, verts, indices, lng, lat, n_confirmed, meshVertices, meshIndices, meshColors, locationName, GraphContainerConfirmed, true);
            if (meshVertices.Count + verts.Length > 65000)
            {
                CreateObject(meshVertices, meshIndices, meshColors, seriesObj, locationName, GraphContainerConfirmed);
                meshVertices.Clear();
                meshIndices.Clear();
                meshColors.Clear();
            }

            CreateObject(meshVertices, meshIndices, meshColors, seriesObj, locationName, GraphContainerConfirmed);
            meshVertices.Clear();
            meshIndices.Clear();
            meshColors.Clear();

            // Recovered Cases
            AppendPointVertices(p, verts, indices, lng, lat, n_recovered, meshVertices, meshIndices, meshColors, locationName, GraphContainerRecovered, false);
            if (meshVertices.Count + verts.Length > 65000)
            {
                CreateObject(meshVertices, meshIndices, meshColors, seriesObj, locationName, GraphContainerRecovered);
                meshVertices.Clear();
                meshIndices.Clear();
                meshColors.Clear();
            }

            CreateObject(meshVertices, meshIndices, meshColors, seriesObj, locationName, GraphContainerRecovered);
            meshVertices.Clear();
            meshIndices.Clear();
            meshColors.Clear();

            // Fatal Cases
            AppendPointVertices(p, verts, indices, lng, lat, n_deaths, meshVertices, meshIndices, meshColors, locationName, GraphContainerFatal, false);
            if (meshVertices.Count + verts.Length > 65000)
            {
                CreateObject(meshVertices, meshIndices, meshColors, seriesObj, locationName, GraphContainerFatal);
                meshVertices.Clear();
                meshIndices.Clear();
                meshColors.Clear();
            }

            CreateObject(meshVertices, meshIndices, meshColors, seriesObj, locationName, GraphContainerFatal);
            meshVertices.Clear();
            meshIndices.Clear();
            meshColors.Clear();

            // Calculating total numbers for the info slate display
            nConfirmedTotal += n_confirmed;
            nRecoveredTotal += n_recovered;
            nFatalTotal += n_deaths;

            if ( i == featuresArray.Count-2)
            {
                timestamp = featuresArray[i]["attributes"]["Last_Update"].AsLong;
            }

        }

        Destroy(p);

        // Assigning total numbers to Text Mesh Pro labels
        tmpConfirmedTotal.text = nConfirmedTotal.ToString();
        tmpRecoveredTotal.text = nRecoveredTotal.ToString();
        tmpFatalTotal.text = nFatalTotal.ToString();
        tmpActiveTotal.text = (nConfirmedTotal - nRecoveredTotal).ToString();

        tmpTimeStamp.text = UnixTimeStampToDateTime(timestamp).ToString();

        // Activate Confirmed by default
        GraphContainerConfirmed.SetActive(true);
        GraphContainerRecovered.SetActive(false);
        GraphContainerFatal.SetActive(false);
            
    }
    private void AppendPointVertices(GameObject p, Vector3[] verts, int[] indices, float lng,float lat,float value, List<Vector3> meshVertices,
    List<int> meshIndices,
    List<Color> meshColors,
    string locationName, GameObject containerObject, bool createLabel)
    {

        Color valueColor = Colors.Evaluate(value * 0.00025f);
        Vector3 pos;
        pos.x = 0.5f * Mathf.Cos((lng) * Mathf.Deg2Rad) * Mathf.Cos(lat * Mathf.Deg2Rad);
        pos.y = 0.5f * Mathf.Sin(lat * Mathf.Deg2Rad);
        pos.z = 0.5f * Mathf.Sin((lng) * Mathf.Deg2Rad) * Mathf.Cos(lat * Mathf.Deg2Rad);
        p.transform.parent = containerObject.transform;
        p.transform.localPosition = pos;
        p.transform.localScale = new Vector3(1, 1, Mathf.Max(0.00001f, value * ValueScaleMultiplier));
        //        p.transform.LookAt(pos * 2);
        p.transform.LookAt(pos * 2 + Earth.transform.position); 

        // Text Label
        if(createLabel == true)
        {
            GameObject textLabel = Instantiate<GameObject>(TextPrefab);
            textLabel.GetComponentInChildren<TextMesh>().text = locationName;
            textLabel.transform.parent = LabelContainer.transform;
            textLabel.transform.localPosition = pos * 1.04f;
            textLabel.transform.LookAt(pos * -3 + Earth.transform.position);
            textLabel.transform.localRotation *= Quaternion.Euler(0, 90, 0);
            //textLabel.GetComponentInChildren<TextMesh>().SetActive(false);
            //textLabel.transform.localPosition += new Vector3(0.3f, 0.0f, 0.0f);

            // Adding in second label to show city and case data in both directions.
            GameObject p2 = Instantiate<GameObject>(textLabel);
            p2.transform.parent = LabelContainer.transform;
            p2.transform.localPosition = pos * 1.04f;
            p2.transform.LookAt(pos * -3 + Earth.transform.position);
            p2.transform.localRotation *= Quaternion.Euler(0, 90, 0);
            TextMesh p2Text = p2.GetComponentInChildren<TextMesh>();
            p2Text.transform.Rotate(0, 180, 0);
            p2Text.anchor = TextAnchor.MiddleRight;
        }

        int prevVertCount = meshVertices.Count;

        for (int k = 0; k < verts.Length; k++)
        {
            meshVertices.Add(p.transform.TransformPoint(verts[k]));
            meshColors.Add(valueColor);
        }
        for (int k = 0; k < indices.Length; k++)
        {
            meshIndices.Add(prevVertCount + indices[k]);
        }


    }
    private void CreateObject(List<Vector3> meshertices, List<int> meshindecies, List<Color> meshColors, GameObject seriesObj, string locationName, GameObject containerObject)
    {
        Mesh mesh = new Mesh();
        mesh.vertices = meshertices.ToArray();
        mesh.triangles = meshindecies.ToArray();
        mesh.colors = meshColors.ToArray();
        GameObject obj = new GameObject();
        obj.transform.parent = containerObject.transform;
        obj.AddComponent<MeshFilter>().mesh = mesh;
        obj.AddComponent<MeshRenderer>().material = PointMaterial;
        //obj.transform.parent = seriesObj.transform;
    }

    private static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
    {
        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp);
        return dtDateTime;
    }

}
[System.Serializable]
public class SeriesData
{
    public string Name;
    public float[] Data;
}
