//This is my code for getting microphone input in Unity(works with VR). You just need to have an AudioSource on the GameObject and set the Microphone input to feed into that AudioSource.Then once you play the AudioSource, source.clip will essentially be a live feed of your microphone input.

source = GetComponent<AudioSource>();
source.Stop();               
source.clip = Microphone.Start(null, true, 1, AudioSettings.outputSampleRate);               
source.Play();

//The trick here is that you most likely don't want to hear the audio played back as it is being recorded, but if you mute the audio source the microphone capture won't work.To get around this, assign a mixer to the AudioSource, and then in the mixer settings, set the Attenuation to as low as it will go.Now the audio is technically still "playing" but you won't be able to hear it. You can now access source.clip and do whatever you want in response to the user's microphone input. 