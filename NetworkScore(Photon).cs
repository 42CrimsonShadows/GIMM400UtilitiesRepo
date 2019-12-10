using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

Shark Class(/*attached to shark object*/)
{
   public Player Owner { get; private set; }

    void Start()
    {
        InitializeOwner(Owner);
    }

    public void InitializeOwner(Player owner)
    {
        Owner = owner;
        Owner = PhotonNetwork.LocalPlayer;
    }
}

Agent Class(/*attached to agent object*/)
{
    public bool isBit = false;
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Shark")
        {
            PhotonView sharkView = other.gameObject.GetComponent<PhotonView>();
            if (!isBit)
            {
                isBit = true;
                rBody.isKinematic = true;
                SharkMovement shark = other.gameObject.GetComponent<SharkMovement>();       //This is the shark script

                if (sharkView.IsMine)
                {
                    shark.Owner.AddScore(1);
                }

            }
        }
    }
}