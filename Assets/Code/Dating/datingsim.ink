Code.ink: 
EXTERNAL place_actors(left_actor_name, right_actor_name)
EXTERNAL change_emotion(emotion,ID)
//Left = 0, right = 1
{place_actors("Actor","Actor 1")}
{change_emotion("Angry",0)}
{change_emotion("Happy",1)}


//Main Story:




Skopje Macedonia, 2023 <br>Komercijalna Bank
-> Bank

== Bank ==
You: Hey mister! You got some time to spare?
Guard: No
*[Nag him] -> Nag
*[Elude to more] -> Elude

== Nag ==
You: Oh come on, not even 5 minutes? There's other guards here, nothing is going to happen.
Guard: Excuse me if you aren’t here for business, I'm gonna have to ask you to leave.
*[Nag him] -> Nag2
*[Elude to more] -> Elude
*[Question authority] -> Question
->END

==Nag2==
You: You can’t even answer my questions?
Guard: No, I'm working. I'm going to ask you again to leave the premise. 
You: Pleaseeeee, it's just a few questions. I'm from out of town. I just want to know if there is anywhere specific I should visit.
->END

==Elude==
You: I have something cool to show you.
Guard: I'm not going to follow, please leave.
->END

==Question==
You: Is this how you normally treat patrons of this establishment? If so I must inform
*[The general public] ->Public
*[The management] ->Management

==Public==
the general public of the poor treatment of us customers
Guard: Alright please step outside.
*[Threaten] ->ThreatenP
*[Seek Pity]->END
*[Think fast]->quiz

==quiz==
You: Pop quiz! 
Guaed:I'm going to have to ask yo-
*[Biology question] -> Biology
*[History question] -> History
*[Pop culture question] -> Pop  
==Biology==
You: What is the name of the family that Otters, skunks, and wolverines all fall under?
Guard: Uhm excuse me?
You: Oh its alright its very normal to need to hear the question again.
Guard: No I-
You: What is the name of the family that Otters, skunks, and wolverines all fall under?
Guard: If I answer the question will you cooperate?
You: What is the name of the family that Otters, skunks, and wolverines all fall under?
Guard: Marsupials?
You: Ooh close but no cigar, the answer I was looking for was Mustelidae.
Guard: ...??? I- I'm going to have to ask you to lea-
*[Pop culture question] -> Pop  
*[History question] -> History
==History==
You: Which famous assination sparked the conflict for world war 2?
Guard: Alright step outside now.
-> END
==Pop==
You: Of the Seven Neko Princess Rangers from the original 1987 show: Neko Princess Rangers Galaxy SAGA, who posesses the "Mars Blaze Mahouken"?
Guard: Easy, that's Akane chan.
You: Correct!
*[Biology question] -> Biology
*[History question] -> History
*[Ask how he knew] -> Fandom
*[Ask another Neko Princess Rangers question] ->NekoQ
->END
==Fandom==
how did you know the answer? And so fast. Are you an NPR fan?
Guard: Am I an NPR fan? Please, you don't even know the half of it.
You: Have you watched every season of g1?
Guard: All of them and the movie
You: Have you seen the OVA?
Guard: All 3 baby
You: Have you watched Galaxy SAGA reboot?
Guard: Unfourtanetly yes, all six + the fillers
You: Yikes brother, been there done that.
*[Ask another Neko Princess Rangers question] -> NekoQ
*[Ask who their oshi is] -> oshi
*[Ask if he's played the games] -> NekoG
*[Ask about Neko Con] -> NekoCon

-> END

==NekoQ==
You: Well then, In the NovaBaron arc, what does Fumie say that causes NovaBaron to lose his cool and reveal his alternate persona, Lavernus.
Guard: "I cannot accept because to do so would be a betreyal of my kin, it would make no better than yourself.
No suffering you can put me through will hurt more than knowing my heart has told lies."
You: Off the top? Wow! You truly are who you say you are, a devout Fumie fan.
*[Ask who their oshi is] -> oshi
*[Ask if he's played the games] -> NekoG
*[Ask about Neko Con] -> NekoCon
==oshi==
You: Who is your oshi? In G1 obviously.
Guard: Fumie chan all the way! 
You: Wow a man of taste I see.
Guard: How could I not aside from being the original shizendere, she's got easily the most versatile and unique Mahouken. What about you? Who's your oshi?
*[Akane(Mars)] -> Akane
*[Emi(Mercury)] -> Emi
*[Hikari(Jupiter)] -> Hikari
*[kohaku(Venus)] -> Kohaku
*[Reina(Neptune)] -> Reina
*[Sora(Uranus)] -> Sora
*[Also Fumie(Saturn)] ->Fumie
==NekoG==
You: Have you played any of the Star defenders?
Guard: Are you kidding? Of course! My favorite is defenders 3 no questions asked.
You: Did you ever beat NovaBaron and Lavernus Prime?
Guard: Yes. I did. Now granted I beat it as an adult and had online guides when I beat him on my second playthrough. As a kid it was way too difficult.
You: Damn! that's impressive. I found it way too daunting a task to ever grind out attempts.
Guard: You missed out, I'm telling you the cutscene was worth it.
You: How many attempts did it take you? Or how many hours?
Guard: A month, every day after work, 2 hour sessions at a time.
You: Gotta give you credit man that's super impressive.
*[Ask another Neko Princess Rangers question] -> NekoQ
*[Ask who their oshi is] -> oshi
*[Ask about Neko Con] -> NekoCon
==NekoCon==
You: Are you going to NekoCon?
Guard: No but I really want to. It's too expensive and I wouldn't be able to go because it's on a work day anywas.
You: Well, keep this between just you and me alright?
Guard: Sure sure.
You: I can get you the hookup if your willing to take the day off, I'm a vip and I can bring one +1 but I don't have any friends who can come with.
Guard: Really!? You would let me come along? Even though we've just met?
You: Look I have the Vip pass right here, if I can let one more person come along why not help out a fellow fan.
Guard: *sniff* I can't thank you enough are you really sure? I can driv us there if you need.
You: Yes thats perfect! Let's get going it starts in 3 hours!
Guard: I can't believe this! it's almost two good to be true. Alright then I'll tell my boss I have to leave for a family emergency.
->END
==Akane==
You: Akane, Easy! She was girl power before girl power. Nobody wanted the smoke and for good reason! She slayed like no other could. Also Emi teasing her about her crush on Shohei never failed to make me laugh.
Guard: I love her and shohei together. It's so frustrating to follow but it keeps you so invested.
*[Ask another Neko Princess Rangers question] -> NekoQ
*[Ask if he's played the games] -> NekoG
*[Ask about Neko Con] -> NekoCon
==Emi==
You: I love Emi and honestly the hate is undeserved. She's a little much, but that's important to her character. 80% of the comedy comes from her shenanagins. And every good team needs a scamp. And you have to admit her Mahouken is easily top 3 coolest.
Guard: I can appreciate a fellow devout for an underrated queen.
You: You know it. We gotta stick together cause it's us versus the world.
*[Ask another Neko Princess Rangers question] -> NekoQ
*[Ask if he's played the games] -> NekoG
*[Ask about Neko Con] -> NekoCon
==Hikari==
You: Call me basic but Hikari is and will always be best girl. She's too good for the rest of them honestly. Every scene is enhanced by her presence and some of the best emotional moments involve her. The perfect older sister to the group.
Guard: Sorry, that's basic for sure. Wouldn't be me but, she's popular for a reason right? I'm not knocking your opinion cause she definitely is deserving of that fanbase.
*[Ask another Neko Princess Rangers question] -> NekoQ
*[Ask if he's played the games] -> NekoG
*[Ask about Neko Con] -> NekoCon
==Kohaku==
You: Oh it's kohaku for sure. Our lesbian queen.
Guard: Well I guess, but she's never confirmed to be lesbian.
You: Uhm yes she basically is, i'm sorry but if you're denying her very clear identity then you're homophobic.
Guard: What? No no it's nothing like that, I just feel like at least for me, she is never confirmed to be a lesbian by the creator, none of her interactions with akane are ever explicitly romantic and akane never recipracates. I believe they're just good friends with a unique bond but nothing more. You can definitely have your own opinion though!
You: Kohakane is not opinion, it's canon. Either way I love her so much, her sheltered clueless rich girl personality perfectly clashes with akane's head first tom boyish character. They're just made for eachother. They're dynamic is what got me through all the fillers.
*[Ask another Neko Princess Rangers question] -> NekoQ
*[Ask if he's played the games] -> NekoG
*[Ask about Neko Con] -> NekoCon
==Reina==
You: TEAM REINA FOREVER. "Mahouken, Neptune's wrath UNLIMITTED!" Chills. Still Chills. I don't care what anyone says about her because she's just wayyy too cool. If you think she isn't top 2 we can never get along. Also she's just too hot, her G1 outfit is PEAK!
Guard: I know right! I love her G1 outfit, her VA literally saves lives with that preformance. 
You: I KNOW RIGHT!
*[Ask another Neko Princess Rangers question] -> NekoQ
*[Ask if he's played the games] -> NekoG
*[Ask about Neko Con] -> NekoCon
==Sora==
You: No disrespect, Sora clears the others E Z. Plus she solos your favorite character, your favorite verse. Her Mahouken is so underrated, it's literally an auto win button that's only countered by bullshit plot convinience and toon force. 
Guard: Yeah that's pretty true I guess. 
*[Ask another Neko Princess Rangers question] -> NekoQ
*[Ask if he's played the games] -> NekoG
*[Ask about Neko Con] -> NekoCon
==Fumie==
You: Much like yourself I believe Fumie is the best written character in the series.
For instance during the NovaBaron arc Episode 97:"I cannot accept because to do so would be a betreyal of my kin, it would make no better than yourself.
No suffering you can put me through will hurt more than knowing my heart has told lies." A line delivered so perfectly I could never look at the series the same. 
On my first watch through I shed tears, much like every subsequent watchthrough.
The single scene was able to found my beleif that she was the culmination and synthesis of Haneyama sensei's genius in theater, media, and culture. 
This is supported by the fact that haneyama's own favorite scene of the anime adaption is during the Univers Tour arc Episode 54:
Fumie stands in the abandoned palace garden that has been unkept and overun by fauna and flora and yet light shines brightly through.
The symbolism is genius, kohaku literally peers into Fumie's heart(the castle), unkept(the emotions and trauma she ignores and leaves unchecked), 
but in this moment we see her tranquility as she's brought back to the place of her trauma(the castle) and the remanant of what was her old life. 
It's a bittersweet moment that solidifies g1 as superior to all other NPR media. The piano musical theme being so subtle and quiet plays so well into this scene it truly boggles my mind! Still iconic after all this time. 
Hatred, pain, and war are the emotions that govern people which destoys them and the world. 
Fumie's character arc teaches us to love our fellow people, friends, family, especially those who live on earth with us. We are not the only ones who live on earth. Be loving and considerate to them as well. 
Guard: *sniff* that was beautiful, I'm honestly moved and so glad I could meet another like minded individual.
*[Ask another Neko Princess Rangers question] -> NekoQ
*[Ask if he's played the games] -> NekoG
*[Ask about Neko Con] -> NekoCon
==Management==
the management of the poor treatment of us customers
Guard: Hey listen we don’t have to go there, i’m sorry if I offended you, i’m just doin my job here.
*[Threaten Management] ->ThreatenM

==ThreatenP==
You: Then I'll be taking this issue up with the general public.
->END

==ThreatenM==
You: Then I’ll be taking this issue up with Management. 
You: Excuse me! May I speak to the Manager of this establishment?
Manager: What’s the issue here?
*[Flirt] -> IntroFlirt
*[Give it to em straight] -> GITEMS

==IntroFlirt==
You: Oh hello there, I feel reassured knowing that a capable looking man such as yourself has come to my rescue. <br>I assume you must be the manager because I can’t imagine you having a position any lower. 
Manager: Well you got that right, I'm the manager, what can I do for ya?
//*[]
//*[]
->END

==GITEMS==
You: Excuse me, are you the manager?
Manager: I am
You: Well I've been mistreated by this employee of yours. He’s patronized me and infringed upon my rights as a customer. 
Manager: Is what I'm hearing true?
Guard: hey listen I just told them they cant be loitering on bank grounds.
*[Gaslight]-> Gaslight
*[Flirt]-> Flirt

==Gaslight==
You: As I recall, you refused me service because I just wanted to have a conversation and admire this beautiful building.<br>My original intentions were never to loiter.
Manager: You can admire the building, but please don't distract my workers.
You: I'm sorry, I was just trying to ask some questions. I'm from out of town.<br>I was wondering what places I should visit. Your guard told me to leave before I could even ask.
->END

==Flirt==
How do you want to flirt?
*[Compliment intelligence]->ComplimentIntelligence
*[Instill confidence]->InstillConfidence
*[Compliment appearance]->ComplimentAppearance
->END

==ComplimentIntelligence==
You: Clearly your a very intelligent man, you've climbed the ranks of the corporate ladder and established yourself as worthy of a prestigious position. Tell me based on your wise insight do you believe that someone who came to a bank to do business would lie about their intentions? I merely tried to make small talk before carrying on and am now facing unjust infrigment of my rights from your fine employee here.
->END

==InstillConfidence==
You: I assure you your judgment and will is absolute, your authority is warranted, and you can, and should, do as you see fit, this worker's behavior is subject to your assesment and you have the power to change this situation for the better and absolve this misunderstanding and injustice.
->END

==ComplimentAppearance==
You: I see your a fine gentleman of culture as your appearance is very well kept and most certanly cultured. So you must also be able to understand the frustration of being condescended to by an uncultured individual, it's unbefitting for people like us to be subservient to those beneath us, let alone those who aren't even capable of grooming their own facial hair. I mean this is a fine establishment and to have someone like him in charge ordering people like us around is a little ridiculous don't you think?
->END


