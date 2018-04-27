using UnityEngine;

public class ArmScript : MonoBehaviour {

    Camera cam;
    AudioSource gunShotSound;

    Vector3 mousePosition;
    Vector3 armPosition;
    Vector3 displacement;
    Vector3 direction;

    float distance;
    float angle;

    SpriteRenderer pirateRenderer;
    SpriteRenderer armRenderer;

    bool flipped = false;
    float bulletCoolDown = -1f;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float bulletVelocity = 25.0f;

    void Start() {
        armRenderer = GetComponent<SpriteRenderer>();
        pirateRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        cam = GameObject.FindObjectOfType<Camera>().GetComponent<Camera>();
        gunShotSound = GameObject.Find("GunShotSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate() {

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        armPosition = transform.position;

        if (mousePosition.x > armPosition.x + 0.5f){

			armRenderer.flipY = true;
			pirateRenderer.flipX = true;

            if (!flipped) {
				transform.position += new Vector3 (0.4f, 0, 0);
				flipped = !flipped;
			}

		}
		else if (mousePosition.x < armPosition.x - 0.5f){

			pirateRenderer.flipX = false;
			armRenderer.flipY = false;

			if (flipped) {
				transform.position -= new Vector3 (0.4f, 0, 0);
				flipped = !flipped;
			}

		}

        displacement = mousePosition - armPosition;
        displacement.z = 0;
        distance = displacement.magnitude;
        direction = displacement / distance;

		angle = Mathf.Atan2(-displacement.y, -displacement.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, angle);

        if (distance > 0.1f && bulletCoolDown <= 0f)
        {
            if (Input.GetMouseButton(0))
            {
                GameObject bulletObj = Instantiate(bulletPrefab, armPosition + direction, transform.rotation);
                bulletObj.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;
                gunShotSound.Play();
                bulletCoolDown = 0.5f;
                Destroy(bulletObj, 2f);
            }
        }

        if (bulletCoolDown > 0f) bulletCoolDown -= Time.fixedDeltaTime;
	}
}