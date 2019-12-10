void CreateRoad()
{

    RoadExit = JustSpawned.transform.Find("ExitPoint");
    SpawnPosition.transform.position = RoadExit.transform.position;
    JustSpawned = Instantiate<GameObject>(ReturnRoad());
    JustSpawned.transform.position = SpawnPosition.transform.position;

    Destroy(Roads[0]);
    Roads[0] = null;
    for (int i = 0; i < (Roads.Length - 1); i++)
    {
        if (Roads[i] == null && Roads[i + 1] != null)
        {
            Roads[i] = Roads[i + 1];
            Roads[i + 1] = null;
        }
    }
    Roads[Roads.Length - 1] = JustSpawned;
}