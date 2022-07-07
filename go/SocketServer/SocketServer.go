package main

import "net"
import "fmt"
import "bufio"
import "os"

func main() {

  var port string = "5000"
  ln, _ := net.Listen("tcp", ":"+port)

  conn, _ := ln.Accept()

  for { 
    message, _ := bufio.NewReader(conn).ReadString('\n')
    fmt.Print(string("Cliente: " + message))

	reader := bufio.NewReader(os.Stdin)
    fmt.Print("Servidor: ")
    text, _ := reader.ReadString('\n')

    fmt.Fprintf(conn, text)
  }
}