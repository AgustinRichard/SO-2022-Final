package main

import "net"
import "fmt"
import "bufio"
import "os"

func main() {

  var port string = "5000"
  conn, _ := net.Dial("tcp", "127.0.0.1:"+port)

  for { 
    reader := bufio.NewReader(os.Stdin)
    fmt.Print("Cliente: ")
    text, _ := reader.ReadString('\n')
    fmt.Fprintf(conn, text)

    message, _ := bufio.NewReader(conn).ReadString('\n')
    fmt.Print("Servidor: " + message)
  }
}
