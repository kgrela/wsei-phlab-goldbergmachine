using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Ball_02 : MonoBehaviour
{
    public GameObject windZone;
    public GameObject ball03;
    public GameObject lampLight;
    
    public Animator fanAnimator;
    public Animator elevatorAnimator;
    public Animator pokerAnimator;
    
    public Transform obj;
    
    public int triggerCounter;
    
    ParticleSystem particlesSystem;
    ParticleSystem.Particle[] particles;
    
    Rigidbody rb;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            Debug.Log("Ball_02 enters Trigger tag ["+triggerCounter+"]");
            triggerCounter += 1;

            if (triggerCounter == 1)
            {
                fanAnimator.Play("Fan_01_Loop", 0, 0f);
                windZone.SetActive(true);
                Debug.Log("Wind zone enabled");
            } else if (triggerCounter == 2)
            {
                fanAnimator.Play("Fan_01_Solid",0,0f);
                windZone.SetActive(false);
                Debug.Log("Wind zone disabled");
            } else if (triggerCounter == 3)
            {
                lampLight.SetActive(true);
                Debug.Log("Lamp light enabled");
            } else if (triggerCounter == 4)
            {
                elevatorAnimator.Play("Elevator_01_Lift", 0, 0f);
                Debug.Log("Elevator goes up");
            } else if (triggerCounter == 5)
            {
                pokerAnimator.Play("Poker_01_Hit", 0,0f);
                rb.velocity = new Vector3(0, 0, -3);
                Debug.Log("Poker hits");
            }
            
        }
    }
    
    void Start()
    {
        triggerCounter = 0;
        particlesSystem = gameObject.GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[1];
        SetupParticleSystem();
        rb = gameObject.GetComponent<Rigidbody>();
    }
 
    void FixedUpdate()
    {
        particlesSystem.GetParticles(particles);
        rb.velocity += particles[0].velocity;
        particles[0].position = rb.position;
        particles[0].velocity = Vector3.zero;
        particlesSystem.SetParticles(particles, 1);
    }
 
    void SetupParticleSystem()
    {
        particlesSystem.startLifetime = Mathf.Infinity;
        particlesSystem.startSpeed = 0;
        particlesSystem.simulationSpace = ParticleSystemSimulationSpace.World;
        particlesSystem.maxParticles = 1;
        particlesSystem.emissionRate = 1;
        particlesSystem.Emit(1);
        particlesSystem.GetParticles(particles);
        particles[0].position = Vector3.zero;
        particlesSystem.SetParticles(particles, 1);
    }
}
