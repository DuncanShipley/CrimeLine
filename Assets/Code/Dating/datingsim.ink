//EXTERNAL SetCharacter(CurrentCharacter)
//EXTERNAL SetEmotion(Emotion)
//EXTERNAL SetBackground(Background)

//~ SetCharacter("Guard")//
Skopje Macedonia, 2023 <br>Komercijalna Bank
-> Bank

==Bank==
You: Hey mister! You got some time to spare?
Guard: No
*[Nag him]-> Nag
*[Elude to more]-> Elude

==Nag==
You: Oh come on, not even 5 minutes? There's other guards here, nothing is going to happen.
Guard: Excuse me if you aren’t here for business, I'm gonna have to ask you to leave.
*[Nag him]-> Nag2
*[Elude to more]-> Elude
*[Question authority]-> Question
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
*[The general public]->Public
*[The management]->Management

==Public==
the general public of the poor treatment of us customers
Guard: Alright please step outside.
*[Threaten]->ThreatenP
*[Seek Pity]->END
*[Think fast]->quiz

==quiz==
You: Pop quiz! 
Guard:What?
{Fire:
Manager: An excellent Idea.
}
->quizQ
==quizQ==
*[Biology question]-> Biology
*[History question]-> History
*[Pop culture question]-> Pop  
==Biology==
You: What is the name of the family that Otters, skunks, and wolverines all fall under?
Guard: Uhm excuse me?
You: Oh its alright its very normal to need to hear the question again.
Guard: No I-
You: What is the name of the family that Otters, skunks, and wolverines all fall under?
{Fire:
Guard: If I answer the question will we stop with the nonsense?
-else:
Guard: If I answer the question will you cooperate?
}
You: What is the name of the family that Otters, skunks, and wolverines all fall under?
Guard: Marsupials?
You: Ooh close but no cigar, the answer I was looking for was Mustelidae.
{Fire:
Manager: How dissapointing.
Guard: This is hardly relevant to anything!
Manager: Next question.
Guard: Ohhh brother come on-
-else:
Guard: ...??? I- I'm putting an end to this charade
}
->quizQ

==History==
You: Which famous assination sparked the conflict for world war 1?
{Fire:
Guard: This is absurd! Who on earth knows that?
Manager: I believe it was arch duke Franz Ferdinand
You: Correct! See I believe this brings your character into question more than my own. 
You: After all it's common knowledge really. 
You: If you don't learn history you are doomed to repeat it. 
You: This defacit of knowledge calls into question your responsibillity.
Manager: Precisely.
->quizQ
-else:
Guard: Alright step outside now.
-> END
}
==Pop==
You: Of the Seven Neko Princess Rangers from the original 1987 show: Neko Princess Rangers Galaxy SAGA, who posesses the "Mars Blaze Mahouken"?
Guard: Easy, that's Akane chan.
You: Correct!
*[Biology question]-> Biology
*[History question]-> History
*[Ask how he knew]-> Fandom
*[Ask another Neko Princess Rangers question] ->NekoQ
->END
==Fandom==
You: how did you know the answer? And so fast. Are you an NPR fan?
Guard: Am I an NPR fan? Please, you don't even know the half of it.
You: Have you watched every season of g1?
Guard: All of them and the movie
You: Have you seen the OVA?
Guard: All 3 baby
You: Have you watched Galaxy SAGA reboot?
Guard: Unfourtanetly yes, all six + the fillers
You: Yikes brother, been there done that.
->Questions
==NekoQ==
You: Well then, In the NovaBaron arc, what does Fumie say that causes NovaBaron to lose his cool and reveal his alternate persona, Lavernus.
Guard: "I cannot accept your offer, because to do so would be a betreyal of my kin, it would make no better than yourself.
No suffering you can put me through will hurt more than knowing my heart has told lies."
{oshi: 
You: Off the top? Wow! You truly are who you say you are, a devout Fumie fan.
}
{Fire && History:
You: Off the top? Very impressive. Perhaps I've misjudged you.
Manager: What does this mean for him?
    You: There's no doubt about it. He has learned the lessons that history teaches us.
    You: Even if through a different medium he is just as cultured as us.
    Manager: What!? Please, do you really beleive so? With all do respect the idea seems far fetched. 
    Guard: No it's true.
    Guard: I have NPR to thank for becoming the person I am today.
    ->Assesment
}
{Fire && not History:
You: Off the top? Very impressive. Perhaps I've misjudged you.
Manager: What do you mean by that?
You: There's no doubt about it. He is very cultured. I believe he has proved himself in this regard.
Manager: Err well how do you suppose that having vast knowledge of this, 
Space- no, Galaxy Princess Rangers or whatever it was called constitutes being cultured?
Guard: Have you considered that maybe you are the uncultured one?
You: He brings up a fair point.
Manager: Ok well now hold on. Nevermind me let's just stay on track.
//-> Move on back to fired or -> ban together against manager (maybe)
}
{not Fire: 
You: Off the top? Very impressive. 
}
{oshi:  
You: Off the top? Wow! You truly are who you say you are, a devout Fumie fan.
}
-> Questions
==oshi==
You: Who is your oshi? In G1 obviously.
Guard: Fumie chan all the way! 
You: Wow a man of taste I see.
Guard: How could I not aside from being the original shizendere, she's got easily the most versatile and unique Mahouken. What about you? Who's your oshi?
*[Akane(Mars)]-> Akane
*[Emi(Mercury)]-> Emi
*[Hikari(Jupiter)]-> Hikari
*[kohaku(Venus)]-> Kohaku
*[Reina(Neptune)]-> Reina
*[Sora(Uranus)]-> Sora
*[Also Fumie(Saturn)]->Fumie
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
->Questions
==NekoCon==
You: Are you going to NekoCon?
Guard: No but I really want to. It's too expensive and I wouldn't be able to go because it's on a work day anywas.
You: {Fire:*Whisper* }Well, keep this between just you and me alright?
Guard: Sure sure.
You: I can get you the hookup if your willing to take the day off, I'm a vip and I can bring a +1 but I don't have any friends who can come with.
Guard: Really!? You would let me come along? Even though we've just met?
You: Look I have the Vip pass right here, if I can let one more person come along why not help out a fellow fan.
Guard: *sniff* I can't thank you enough are you really sure? I can drive us there if you need.
You: Yes thats perfect! Let's get going it starts in 3 hours!
{not Fire:Guard: I can't believe this! it's almost two good to be true. Alright then I'll tell my boss I have to leave for a family emergency.}
{Fire:Manager: Go where exactly?} //convinceM
->END
==Akane==
You: Akane, Easy! She was girl power before girl power. 
You: Nobody wanted the smoke and for good reason! She slayed like no other could. 
You: Also Emi teasing her about her crush on Shohei never failed to make me laugh.
Guard: I love her and shohei together. It's so frustrating to follow but it keeps you so invested.
->Questions
==Emi==
You: I love Emi and honestly the hate is undeserved. She's a little much, but that's important to her character. 
You: 80% of the comedy comes from her shenanagins. And every good team needs a scamp. 
You: And you have to admit her Mahouken is easily top 3 coolest.
Guard: I can appreciate a fellow devout for an underrated queen.
You: You know it. We gotta stick together cause it's us versus the world.
->Questions
==Hikari==
You: Call me basic but Hikari is and will always be best girl. She's too good for the rest of them honestly. 
You: Every scene is enhanced by her presence and some of the best emotional moments involve her. 
You: The perfect older sister to the group.
Guard: Sorry, that's basic for sure. Wouldn't be me but, she's popular for a reason right? I'm not knocking your opinion cause she definitely is deserving of that fanbase.
->Questions
==Kohaku==
You: Oh it's kohaku for sure. Our lesbian queen.
Guard: Well I guess, but she's never confirmed to be lesbian.
You: Uhm yes she basically is, i'm sorry but if you're denying her very clear identity then you're homophobic.
Guard: What? No no it's nothing like that, I just feel like at least for me, she is never confirmed to be a lesbian by the creator, none of her interactions with akane are ever explicitly romantic and akane never recipracates. I believe they're just good friends with a unique bond but nothing more. You can definitely have your own opinion though!
You: Kohakane is not opinion, it's canon. Either way I love her so much, 
You: her sheltered clueless rich girl personality perfectly clashes with akane's head first tom boyish character. 
You: They're just made for eachother. 
You: Their dynamic is what got me through all the fillers.
->Questions
==Reina==
You: TEAM REINA FOREVER. "Mahouken, Neptune's wrath UNLIMITTED!" Chills. Still Chills. I don't care what anyone says about her because she's just wayyy too cool. If you think she isn't top 2 we can never get along. Also she's just too hot, her G1 outfit is PEAK!
Guard: I know right! I love her G1 outfit, her VA literally saves lives with that preformance. 
You: I KNOW RIGHT!
->Questions
==Sora==
You: No disrespect, Sora clears the others E Z. Plus she solos your favorite character, your favorite verse. Her Mahouken is so underrated, it's literally an auto win button that's only countered by bullshit plot convinience and toon force. 
Guard: Oh really? Than how was dodonzora able to defeat her?
You: Again plot convinience, If she had just used jetstream-
Guard: But she did! She was speed blitzed and overpowered. There's no excuse there.
You: She was nerfed! It's an unfair comparison
Guard: NovaBaron?
You: Plot convinience and direct counter
Guard: Gamek?
You: Plot convinience and she didn't even get beaten by him in combat! She just couldn't stop him from activating the generator.
Guard: As far as i'm concerned that counts as a loss.
You: BULLSHIT
Guard: Whatever you say I guess.
->Questions
==Fumie==
You: Much like yourself I believe Fumie is the best written character in the series.
{not NekoQ: You: For instance during the NovaBaron arc Episode 97:"I cannot accept because to do so would be a betreyal of my kin, it would make no better than yourself.}
{not NekoQ:You: No suffering you can put me through will hurt more than knowing my heart has told lies." A line delivered so perfectly I could never look at the series the same.} 
{not NekoQ:You: On my first watch through I shed tears, much like every subsequent watchthrough.}
{not NekoQ:You: The single scene was able to found my beleif that} {NekoQ:You: }she was the culmination and synthesis of Haneyama sensei's genius in theater, media, and culture. 
You: This is supported by the fact that haneyama's own favorite scene of the anime adaption is during the Universe Tour arc Episode 54:
You: Fumie stands in the abandoned palace garden that has been unkept and overun by fauna and flora and yet light shines brightly through.
You: The symbolism is genius, kohaku literally peers into Fumie's heart(the castle), unkept (the emotions and trauma she ignores and leaves unchecked), 
You: but in this moment we see her tranquility as she's brought back to the place of her trauma(also the castle in a literal sense) and the remanant of what was her old life. 
You: It's a bittersweet moment that solidifies g1 as superior to all other NPR media. The piano musical theme being so subtle and quiet plays so well into this scene it truly boggles my mind! Still iconic after all this time. 
You: Fumie's character arc teaches us to love our fellow people, friends, family, especially all of those who live on earth with us. We are not the only ones who live on earth. Be loving and considerate to them as well. 
Guard: *sniff* that was beautiful, I'm honestly moved and so glad I could meet another like minded individual.
->Questions
==Questions==
    *[Ask who their oshi is]-> oshi
    *[Ask if he's played the games]-> NekoG
    *[Ask about Neko Con]-> NekoCon

    *{not NekoQ}[Ask another Neko Princess Rangers question]-> NekoQ



==Management==
the management of the poor treatment of us customers
Guard: Hey listen we don’t have to go there, i’m sorry if I offended you, i’m just doin my job here.
*[Threaten Management]->ThreatenM

==ThreatenP==
You: Then I'll be taking this issue up with the general public.
->END

==ThreatenM==
You: Then I’ll be taking this issue up with Management. 
You: Excuse me! May I speak to the Manager of this establishment?
Manager: What’s the issue here?
*[Flirt] -> IntroFlirt
*[Give it to em straight]-> GITEMS

==IntroFlirt==
You: Oh hello there, I feel reassured knowing that a capable looking man such as yourself has come to my rescue. <br>I assume you must be the manager because I can’t imagine you having a position any lower. 
Manager: Astute observation, I am the manager, How may I be of service to you?
*[Compliment intelligence]->ComplimentIntelligence
*[Instill confidence]->InstillConfidence
*[Compliment appearance]->ComplimentAppearance
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
You: Clearly your a very intelligent man, you've climbed the ranks of the corporate ladder and established yourself as worthy of a prestigious position. 
You: Tell me based on your superior insight do you believe that someone who came to a bank to do business would lie about their intentions? 
You: I merely tried to make small talk before carrying on and am now facing unjust infrigment of my rights from your fine employee here.
Manager: Well when you put it like that, I can't dispute it. Excuse my employee's behavior, to slander you with language like "loitering" is not representative of our business. Please by all means carry on.
You: Excellent thank you so much for understanding.
//go on a date with Manager
//go back to bothering the guard
->END

==InstillConfidence==
You: I assure you your judgment and will is absolute, your authority is warranted,
You: you can, and should, do as you see fit, this worker's behavior is subject to your assesment and you have the power to change this situation for the better and absolve this misunderstanding and injustice.
Manager: How would you suggest I go about doing so?
Guard: Hey uh are we being serious right now?
Manger: Silence, customers come first
*[Fire that man]->Fire
//*[]
//*[]
->END

==ComplimentAppearance==
You: I see your a fine gentleman of culture as your appearance is very well kept and most certanly cultured. 
You: So you must also be able to understand the frustration of being condescended to by an uncultured individual, 
You: it's unbefitting for people like us to be subservient to those beneath us,
You: let alone those who aren't even capable of grooming their own facial hair.
You: I mean this is a fine establishment and to have someone like him in charge ordering people like us around is a little ridiculous don't you think?
Manager: Well hehe, I suppose that's all true, I do take pride in my cleanliness. 

->END
==Fire== 
You: Isn't it obvious. His position as a guard must be terminated at once.
Guard: Please. That's absurd.
Manager: Well hold on
Guard: WHAT! BOSS???
Manager: Well some assesment can't hurt. It's of the utmost importance that my employee's take their job as seriously as I take mine.
Guard: Listen, with all do respect you're entertaining the idea of a miscreant customer. Do you hear yourself?
You: Miscreant? Excuse me, You are most definitely in need of assesment.
Manager: Precisely. Now then how should we carry out this assesment.
->Assesment
==Assesment==
*[Test their general knowledge]->quiz
*[Test their morality]->morality
*[Test their abillity to apprehend someone]->Apprehend
==morality==
You: Let's test you're morality shall we?
Manager: Splendid idea, this will help illuminate your character and expose any flaws.
You: The trolley problem goes as follows:
You: There is a runaway trolley barreling down the railway tracks. 
You: Ahead, on the tracks, there are five people tied up and unable to move.
You: The trolley is headed straight for them. You are standing some distance off in the train yard, next to a lever. 
You: If you pull this lever, the trolley will switch to a different set of tracks. 
You: However, you notice that there is one person on the side track. 
You: You have two (and only two) options:
You: Do nothing, in which case the trolley will kill the five people on the main track. 
You: or,
You: Pull the lever, diverting the trolley onto the side track where it will kill one person.
You: What do you do?
Guard: The people's lives are of the upmost importance. I will pull the lever even if there's blood on my hands to save the lives of more people.
Manager: Ah ha, here we see the character flaws begin to shine through, obviously the correct answer is to abstain from pulling the lever, 
Manager: In doing so, the blood is on your hands, society will not be able to see past it.
You: Precisely.
Guard: You're kidding!
Manager: What else should we test him on?
//*[]
//*[]
->END
==Apprehend==
Manager: Interesting. That would be relevant to their abillity to provide value to the company. How do you suppose we test this?
You: It's simple, given a 5 second head start I will attempt to get away from the bank, you must be able to catch me within the hour timer. Failure to do so and you will be terminated. Make sense?
Guard: Please, this is absurd. Also you don't truly believe you can escape from me can you? I mean, it is literally my job.
You: Oh ho? Let's see you put your money where your mouth is.
Guard: Ha! You're gonna regret ever challenging my authority.
Manager: Well that settles it, on the count of 3.
Manager: 3..
Manager: 2..
Manager: 1..
Manager: GO!
*[Look for hiding places in the city]-> Hiding
*[Run towards traffic]-> Traffic
*[Head up to the rooftops]-> Rooftops
==Hiding==
You: But where to hide...
*[Beneath the bridge]->Bridge
*[Coffee shop]->Coffee
*[Rooftops]->RoofHide
==Bridge==
You: The guard should be on the hunt now.
Homeless Man: The feds? They're coming???
You: Oh hello, no don't worry you'll be just fine.
Homeless Man: YOU! You're one of them aren't you! 
You: Whoa whoa hold on man I mean no harm, lets put the knife away huh?
Homeless Man: THATS WHAT ONE OF THEM FEDS WOULD SAY YOU SNAKE
*[Fight]->FightH
*[Run]->RunH
*[Call for help]->HelpH
*[Offer a special service]->ServiceH
==FightH==
You: I'm sorry but it has to be done, I don't have time for this.
Homeless Man: DIE FED BASTARD
*[Lethal counterattack]->Lethal
*[Attempt to Paralize]->Paralize
==Lethal==
/*Snap*/
You: I'm sorry it had to be done,
You: Can't afford to have any witnesses. Wrong place at the wrong time.
/*Image of guard in background*/
You: Shit why's he over here?? And moreover why is he coming this way?
*[Run]->RunH
//*[Hide]->HideBridge
//*[Hide the body]->Body
==Paralize==
/*Snap*/
You: I'm sorry it had to be done,
You: You will be paralized for the time being and you'll be fully recovered in sixteen hours, I just need you to be quiet for the time being.
/*Image of guard in background*/
You: Shit why's he over here?? And moreover why is he coming this way?
*[Run]->RunH
//*[Hide]->HideBridge
//*[Hide the body]->Body
==RunH==
You: Ok ok i'll get out of your space, my bad man.
*[Coffee shop]->Caught
*[Rooftops]->Caught
==HelpH==
You: Someone please! Help me!
Homeless Man: Ohhhhh no, n-no no no. You're not going anywhere.
Guard: Ha! I've caught you- oh, in need of a proffesional?
You: I'm sorry I ever doubted you, I need you.
Guard: Uh hehe, wow, I-I suppose so, looks to me like you could use a hand.
You: Please help me I'll do anything.
Guard: Anything!? Well when you make a face like that how can I refuse, this does mean that I win though alright? Don't get the wrong idea or whatever.
Homeless Man: YOU'LL NEVER TAKE ME!
Guard: Right, the situation at hand. 
/*Punch*/
You: Thank you so much. You're my hero, you really saved me!
Guard: Please, i'm just doing my job here.
You: What can I do to make it up to you?
->END
==ServiceH==
You: Hey we don't have to do this, maybe we can work something out between us. How long has it been since you've had any carnal release?
Homeless Man: Huh... uh hehe yes that sounds awesome.
You: Well let's see what were workin with here, /*zip*/ oh my.
Homeless Man: Ah ha.. ohh yeahh hurry hurry
/*Black screen*/
You: There we go, he should be out for the count now.
/*Image of guard in background*/
You: Shit why's he over here?? And moreover why is he coming this way?
*[Run]->Caught
//*[Hide]->HideBridge*[Hide the body]->Body//
->END
==Coffee==
You: The guard should be on the hunt now.
Barista: Welcome, how can I help you?
*[Order a drink]->Order
//*[Bribe to switch outfits/places]->Disguise*[Hide in the bathroom]->Bathroom
==RoofHide==
You: The guard should be on the hunt now.
->END
==Traffic==
You: The guard should be on the hunt now.
Guard: Stop there!
You: Excuse me
/*Cars Honk*/
Guard: You're a maniac!
You: I'm winning though aren't I?
->END
==Rooftops==
You: The guard should be on the hunt now.
->END
==Order==
You: Yeah tell you what, can I get a grande, flat white, with an extra shot?
Cashier: Yeah that'll be 5.99$
Cashier: And what name should I call for your order?
You: Robin
Cashier: Would you like to leave a tip?
You: Here's a dollar.
Cashier: Thank you, your order will be right on it's way.
You: Perfect. Hide where he'll least expect it. Plain sight.
->END
==Caught==
You: Shit I gotta go! 
Guard: Gotcha! Don't fight back.
You: Not bad, that's a clean rear naked choke hold, you seem to know what you're doing. 
You: Although I'm not so sure the law lets security guards put people in choke holds, I'll let you because admittdley you've bested me.
Guard: I'm glad that at the very least you have the brains to recognize when you're out of options. 
Guard: Now lets head back so I can prove myself to the boss.
*[Surprise Counterattack]->Failedatk
[WalkBack]->WalkBack
*[Seduce]->Seduce
*[Bribe]->Bribe
==Bribe==
You: Hey listen we can work something out, 
You: We don't have to go back, 
You: how about a little treat shows up in your venmoe,
You: I get out of your hair and we never have to cross paths again. Huh? Not so bad right?
Guard: How much are we talking? Cause to put it lightly the bidding starts very high. I'm not about to stake my job for nothing.
*[50$]->Fifty
*[100$]->Hundred
*[1000$]->Thousand
==Fifty==
You: 50$ call it good?
Guard: HAH that's rich,
Guard: Now let's get this over with and head back.
*[100$]->Hundred
*[1000$]->Thousand
[WalkBack]->WalkBack
*[Surprise Counterattack]->Failedatk
*[Seduce]->Seduce
==Hundred==
You: Tell ya what a whole hundred and we go our seperate ways.
Guard: Getting fired is gonna cost me a whole lot more than a hundred dollars.
You: How do you know your getting fired? It's really not that deep and i'm sure your boss is a sensible man.
Guard: Then clearly you don't know him well enough,
Guard: No disrespect to him.
*[1000$]->Thousand
[WalkBack]->WalkBack
*[Surprise Counterattack]->CounteratkG
*[Seduce]->Seduce
==Thousand==
You: Thousand dollars final offer.
Guard: How do I know you even got a thousand dollars lying around, go ahead lets see that stack.
You: Now hold on, I don't got it on me, maybe I give you my contact info, we figure this out when I've withdrawn that money.
Guard: Well if you're in such a rush why don't we head back to the bank and withdraw it there?
[WalkBack]->WalkBack
*[Surprise Counterattack]->Failedatk
*[Seduce]->Seduce
==Failedatk==
You: But will he expect this?
/*Fighting game noise*/
/*Pause*/
...
Guard: That was mighty slick there chief, you've crossed the line though.
Guard: We're headed back,
Guard: And don't even think about trying anything funny.
You: That's quite the tight grip there mister.
Guard: ...
[WalkBack]->WalkBack
==CounteratkG==
You: But will he expect this?
/*Fighting game noise*/
/*Pause*/
You: Nice I can't believe that actually worked. This guy is a real oaf.
->END
==Seduce==
You: Hold on now we can work something out, 
You: We're in no rush to be anywhere.
Guard: That's just not true.
You: Maybe I provide you a special little service, you leave me be, we go our seperate ways huh? 
You: After all this tight grip has got me feeling a certain sorta way. You don't feel that?
Guard: ... I uh
Guard: AhEm uh, hehe...  what sorta service do you have in mind?
You: Whatever your in the mood for darling.
Guard: Your simple tricks won't work on me
You: Perhaps I'll just show you what I mean.
You: As they say, actions speak louder than words.
//Fade to black and then unzip noise
Guard: That was incredible. I can't even move. I need a second just to cool off.
->END
==WalkBack==
You: Alright, alright I submit. 
You: Let's head back.
Guard: Good. Don't try anything funny.
*[Stay silent and walk back in complience]->Comply
*[strike up some conversation]->Conversation
==Comply==
//fade to black
Manager: Well well well, it appears you've proven yourself useful.
Guard: So I'm vindicated and off the hook right boss?
Manager: That was the terms of our deal.
Guard: Sweet! Well, without anymore delay let's get back to doing our jobs.
Manager: Excellent idea!
Guard: Great. Then i'm gonna have to ask you to leave the premises.
You: Urk you'll regret that, you will.
//Bad Ending
->END
==Conversation==
You: This view is quite something huh? I envy you getting paid to hangout in this beautiful area of town.
Guard: It really is, although, after spending every day here you begin to take it for granted.
*care for ice cream?
    You: Since were here you wanna get some ice cream? My treat.
    Guard: What's your angle here?
    You: I'm craving something sweet and it's nice weather. What about it?
    Guard: Well when you put it like that.
    ->IceCream
*Sit down on the viewside bench
    You: Since were here why not stop to sit and admire the view?
    Guard: Come on we have places to be.
    ->Comply
==IceCream==
Salesman: Hey there folks what can I get for ya today?
Guard: Can I get a split scoop, pistachio and chocolate mousse, in a waffle cone with sprinkles, whipped cream, peanuts, and the pirouettes?
Salesman: For sure!
You: What the hell are you thinking??
You: Hold on you think i'm paying for all that? 
You: Fat chance.
Guard: Well we could just head back now if your unwilling to keep your word.
You: No no no alright fine get whatever.
Salesman: And what can I get for you?
*[Sorbet]->Sorbet
*[French Vanilla]->Vanilla
*[Pistachio]->Pistachio
==Pistachio==
    {Fumie:Guard: Pistachio huh? We truly have so much in common.}
    {not Fumie:
    Guard: Listen you don't have to pretend in order to impress me.
    You: What are you even talking about?
    Guard: You copied my order plain and simple.
    You: Pfft hardly, you ordered enough ice cream to make a cow lactose intolerant.
    Guard: Oh shut up.
    }
->Total
==Vanilla==
{Hikari:
Guard: You're about as basic as they come!
You: Excuse me? What's that supposed to mean?
Guard: Well of all the NPR's your oshi is Hikari and of all the flavors you can you pick vanilla.
You: Well if they're superior than I see no issue.
}
Guard: Of all the wonderful flavors? 
You: Who's paying again?
Guard: Fair enough.
->Total
==Sorbet==
Guard: Good choice. Maybe I should've gotten that.
You: I can give you some if you want to try it.
Guard: If you don't mind uhm I would love to try it.
->Total
==Total==
Salesman: Alrighty then that will be 19.35$
You: Here you are.
Salesman: Excellent have an amazing rest of your day!
You: 19.35$? Really?
Guard: Sorry. But maybe let's not dwell on it so much.
Guard: I mean after all, we didn't come all this way to sit around and bicker right?
* {Sorbet} [Share ice cream]
You: Do you want to try mine?
Guard: If your ok with it.
You: Here you go.
Guard: Oh right off the spoon? 
You: I'm sorry I-
Guard: No it's ok, 
Guard: ahem! 
Guard: I uh- I guess I don't really mind.
->DONE
* [Respond annoyed] 
You: Ugh your right but don't think i'm gonna let this go so easily
Guard: Pfft haha oh man, alright, fair enough. 
You: I'm glad you think this is funny.
Guard: Come on don't be like that.
->DONE
* [Flirt]
You: Despite your proffesional demeanor you're quite the scamp aren't you? 
You: It's cute. I like that about you.
Guard: ...
Guard: Thanks. I've never really had anybody say something like that to me.
You: I'm honored to be your first.
Guard: Honestly i've never even really dated anybody before.
    **{oshi}[ask out]->AskOutOshi
    **{not oshi}[ask out]->AskOut
    **[Pity and manipulate]
    You: Oh dear you poor thing.
    You: It doesn't have to be that way.
    Guard: What do you mean by that?
    You: I can change that for you.
    Guard: How?
    You: You can become my date and I will spoil you. I have just one request in return.
    Guard: Name your condidtion.
    ***[Ask for the master password to the vault]
    You: Tell me the master password to the bank's vault.
    ->END
    ***[Use the guards phone to ask the Manager for the vault password]
    You: Allow me to use your phone and talk to the manager.
    Guard: Why do you need to talk to the manager?
        ->END
    ***[Ask for the manager's contact number]
    You: Give me your manager's number.
        Guard: Why do you need to talk to the manager?
        ->END
    ->DONE
->END
==AskOutOshi==
You: I can change that for you.
Guard: Excuse me?
You: I know we just met but I think there's a real chance for this to go somewhere. 
You: So what do you say will you go out with me?
{Fumie or Akane or Emi or Hikari or Reina:
Guard: I-I I don't know what to say.
Guard: This is all so sudden.
Guard: *heavy breathing* I uh-
You: Hey calm down. 
You: Catch your breath. 
You: Everything is gonna be alright.
Guard: phew, thanks. 
Guard: ... I have made my decision.
You: ...
Guard: Yes. I would be happy to go out with you.
->Date
}
{Kohaku or Sora:
Guard: I don't know what to say.
Guard: This is all so sudden.
Guard: Uh oh gosh
You: Uhm are you good?
Guard: Yeah sorry I just had to calm my nerves down there for a second.
You: So what's it gonna be?
Guard: ... I have made my decision.
You: Go ahead.
Guard: I'm sorry but I'm not intrested.
You: Ugh what? Are you serious? Fine, your loss.
You walk back in silence...
->Comply
}
->END
==AskOut==
You: I can change that for you.
Guard: Excuse me?
You: I know we just met but I think there's a real chance for this to go somewhere. 
Guard: I don't know what to say.
Guard: This is all so sudden.
Guard: Uh oh gosh
You: Uhm are you good?
Guard: Yeah sorry I just had to calm my nerves down there for a second.
You: So what's it gonna be?
Guard: ... I have made my decision.
You: Go ahead.
Guard: I'm sorry but I'm not intrested.
You: That's alright. I understand.
You walk back in silence...
->Comply
==Date==
Date start!


->END

