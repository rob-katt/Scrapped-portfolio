using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

/*static double points(int D, int T ,int K)
{
    double V = D / T;
    double Dh = (D / K) * 100;
    double Vh = (V / K) * 100;


    
    
   

    double Pv = Pvm * Vh / V0;
    double Pd=Pdm;
    double P = F*(Pv+Pd);
    return P;
}*/
static void DayCalc(List<int> time, List<int> distance, int TrackDistance)
{
    double n1 = 0; //number of people that have achived minimum distance
    bool cleared;
    foreach (int i in distance)
    {
        if (i > 50)
        {
            n1++;
            cleared = true;
        }
    }
    double n2 = 0; // number of people that cleared the course
    
    foreach (int i in distance)
    {
        if (i > TrackDistance)
        {
            n1++;
        }
    }

    double D0 = 0; //max distance traveled
    foreach (int i in distance)
    {
        if (i > D0)
        {
            D0 = i;
        }
    }
    
    double V0 = 0; //max velocity
    for (int i = 0; i < distance.Count;)
    {
        
        
        if ((distance[i] * 60)/ (time[i]) > V0) 
        {
            V0 = (distance[i] * 60)/ (time[i]);
        }
        i++;
    }

    double N = time.Count;
     //antal deltagare som har nåt Dm. Dm = 50km
    
    


   
    
    double Pvm = (2 / 3) * (n2 / N) * 1000; //max velocity points
    double Pdm = 1000 - Pvm; //max distance points

    double F = 1.25 * n1 / N; // if F>1 then F=1 
    if(F>1)
    {
        F = 1;
    }


    Console.WriteLine("compleated:"+n1);
    Console.WriteLine("attendence: "+N);
    Console.WriteLine("Max D:"+D0);
    Console.WriteLine("max V:"+V0);
}




List<string> name = new List<string>();
List<int> Time = new List<int>();
List<int> Distance = new List<int>();


Time.Add(60);
Distance.Add(100);
Time.Add(80);
Distance.Add(100);
Time.Add(55);
Distance.Add(100);
Time.Add(70);
Distance.Add(40);
while(true)
{
    Console.WriteLine("---------------------------------------------");
    Console.WriteLine("| Gliding Point Calculator");
    Console.WriteLine("---------------------------------------------");
    Console.WriteLine("| 1: Read");
    Console.WriteLine("| 2: calculate");
    Console.WriteLine("| 3: show");
    Console.WriteLine("| 0: exit");
    Console.WriteLine("---------------------------------------------");
    string menu = Console.ReadLine();

    Console.Clear();


    switch (menu)
    {
        case "1":
            {

                break;
            }
        case "2":
            {
                DayCalc(Time, Distance, 100);
                break;
            }
        case "3":
            {

                break;
            }
        default:
            {
                break;
            }
    }
    
}



string FileTemp;
FileTemp = File.ReadAllText("C:\\Temp\\Temp.txt");


/*

while(true)
{
    string FileTemp = "";
    try
    {
        string tempLine = "";
        FileTemp = File.ReadAllText("C:\\Temp\\Temp.txt");
       

        using (StreamReader sr = new StreamReader("C:\\Temp\\Temp.txt"))
        {
            int NumberOfLines = 0;
            
            List<string> lines = new List<string>();
            
            while ((tempLine = sr.ReadLine()) != null)
            {
                lines.Add(tempLine);
                NumberOfLines++;
                if (sr.Peek == null)
            {
                Console.WriteLine("end");
            }
            }
            int i = 0;
            foreach (string line in lines)
            {
                if (i < (NumberOfLines-1))
                {
                    Console.WriteLine(line);

                }
                else
                {
                    Console.Write(line);
                    
                }
                i++;

            }
            
            
        }
       
    }
    catch
    {
    
    }
   
    

    ConsoleKeyInfo cki;
    cki = Console.ReadKey();
    string FileAdd = Convert.ToString(cki.KeyChar);
    if (cki.Key == ConsoleKey.Backspace)
    {
        using (StreamWriter sw = File.CreateText("C:\\Temp\\Temp.txt"))
        {
            if (FileTemp.Length != 0)
            {
                sw.Write(FileTemp.Remove(FileTemp.Length - 1));
            }
           
        }
    } 
    else
    {
        using (StreamWriter sw = File.CreateText("C:\\Temp\\Temp.txt"))
        {
            sw.Write(FileTemp + FileAdd);
        }
    }
      


    Console.Clear();
}


*/
