//Hey everyone!This is just a fun flying AI that follows a target transform. I use it for the enemies in my individual game and I like the way it looks.I wrote it myself while messing with code when I tutor.

//You can use it to create a flying path for an AI by putting the code on an empty gameobject and teleporting it to the next transform once the ai gets close.


public Transform target;

    public Rigidbody rigid;

    public float speed;

    private Vector3 direction;


    void Start()

    {

        rigid = this.gameObject.GetComponent<Rigidbody>();

    }

    void Update()

    {

        float distanceToTarget = Vector3.Distance(this.transform.position, target.position); //Update GameObject's distance to target


        if (distanceToTarget <= 3)

        {

            //Do something like attack the target, but for the flying ai path example I'll move the goal target to it's next position.

            target.position = new Vector3(Random.Range(-30, 30), Random.Range(1, 30), Random.Range(-30, 30));

        }



        FlyTowards();



        GetDirection(); //Update GameObject's target direction

        //A Vector3 property calculating the Gameobject's target direction  

        public Vector3 GetDirection()

        {
            // Gets a vector that points from the player's position to the target's.       

            var heading = target.position - this.transform.position;

            //Find distance     

            var distance = heading.magnitude;

            direction = heading / distance; // This is now the normalized direction.
            return direction;
        }


        public void FlyTowards()

        {

            rigid.velocity = direction * speed; //making the gameobject fly

            Quaternion targetRotation = Quaternion.LookRotation(direction); //making the gameobject face the target       

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime); //actually transforming the rotation using a Quaternion slerp so that the turn is smooth  

        }
    }
