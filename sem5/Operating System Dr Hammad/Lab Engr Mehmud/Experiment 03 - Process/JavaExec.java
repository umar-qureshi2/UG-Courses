 
import java.util.*;
import java.io.*;
import java.lang.management.*;

public class JavaExec {

    public JavaExec() {
    }

	public static void main(String args[])
    {
        try
        {            
            Runtime rt = Runtime.getRuntime();
            Process proc = rt.exec("freecell");
            System.out.println(ManagementFactory.getRuntimeMXBean().getName());
            Thread.sleep(2000);
            proc.destroy();
            int exitVal = proc.waitFor();
            System.out.println("Process exitValue: " + exitVal);
            //Process proc1 = rt.exec("calc");
            //System.out.println(ManagementFactory.getRuntimeMXBean().getName());
            //Thread.sleep(2000);
            //proc.destroy();
            //proc1.destroy();
        } 
        catch (Exception t)
        {
            t.printStackTrace();
          }
    }
}
