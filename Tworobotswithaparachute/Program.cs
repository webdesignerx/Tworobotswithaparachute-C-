using System;

namespace testnew
{
    class MainClass
    {
        static int NUMBER_OF_STEPS = 0;

        public static void Main(string[] args)
        {
            int random1 = createRandomNumber();
            int random2 = createRandomNumber();
            Robot robot1 = new Robot(random1, random2,"robot1"); 
            Robot robot2 = new Robot(random2, random1,"robot2");
            MakeTheRobotsMeet makeTheRobotsMeet = new MakeTheRobotsMeet();
            Console.WriteLine("robot1 landing at: " + random1); 
            Console.WriteLine("robot2 landing at: " + random2); 

            while (!robot1.didWeMeet(robot2))
            {
                
                makeTheRobotsMeet.makeRobotsMeet(robot1);
                makeTheRobotsMeet.makeRobotsMeet(robot2);
                NUMBER_OF_STEPS++;
            }
            Console.WriteLine("I found robot2");
            Console.WriteLine("Found at: " + robot1.getWeMeetAt());
            Console.WriteLine("Number of steps: " + NUMBER_OF_STEPS);
        }
        private static int createRandomNumber()
        {
            System.Random rnd = new System.Random();
            return rnd.Next(-1000,1000); // + sonsuz - sonsuz
        }
    }
}
public class Robot
{
private string name;
private int weMeetAt;
private int parachuteLocationOfThisRobot, parachuteLocationOfTheOtherRobot;
private int currentLocation;

public Robot(int parachuteLocationOfThisRobot, int parachuteLocationOfTheOtherRobot, string name)
{
currentLocation = parachuteLocationOfThisRobot;
this.parachuteLocationOfThisRobot = parachuteLocationOfThisRobot;
this.parachuteLocationOfTheOtherRobot = parachuteLocationOfTheOtherRobot;
this.name=name; 
}

public void moveLeft()
{
        
        currentLocation--;
        //Console.WriteLine(name + " moves left." + "current location: " + currentLocation); 
    }

public void moveRight()
{
        currentLocation++;
        //Console.WriteLine(name + " moves right." + "current location: " + currentLocation);

    }

public void noOperation()
{
return;
}

public bool findParachute()
{
return currentLocation == parachuteLocationOfTheOtherRobot;
}

public bool didWeMeet(Robot otherRobot)
{
if (currentLocation == otherRobot.currentLocation)
{
    weMeetAt = currentLocation;
    return true;
}     
    return false;
}

public int getCurrentLocation()
{
return currentLocation;
}
public int getWeMeetAt()
{
return weMeetAt;
}
}
public class MakeTheRobotsMeet
{
private bool moveOpposite = false;
public void makeRobotsMeet(Robot robot)
{
if (robot.findParachute())
{
    robot.noOperation();
    moveOpposite = true;
}
else if (moveOpposite)
{
    robot.moveRight();
}
else
{
    robot.moveLeft();
}
}
}