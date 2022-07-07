const net = require('net');
const readline = require('readline-sync')

const server = net.createServer()
console.log('Server levantado')

server.on('connection', (socket)=>{
    console.log('Conexión aceptada')
    socket.on('data', (data)=>{
        console.log('\nCliente: ' + data)
        sendLine()
    })

    socket.on('close', ()=>{
        console.log('Conexión finalizada')
    })

    socket.on('error', (err)=>{
        console.log(err.message)
    })

    function sendLine(){
        var line = readline.question('Servidor: ')
        if (line == "0"){
            socket.end()
        }else{
            socket.write(line + "\n")
        }
    
    }

})

server.listen(5000, ()=>{
    console.log('Escuchando en puerto: ', server.address().port)
})