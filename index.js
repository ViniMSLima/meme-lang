const fs = require('fs')

dictFunc = {
    0 : console.log,
    1 : eval,
    5 : () => { },
}



fs.readFile("./codigin.txt", 'UTF-8' , (err, arq) => {
    let json = JSON.parse(arq)
    
    let strings = []
    let aux = []
    json.data.forEach( e => {
        aux.push(String. fromCharCode(e))
        if (e == "@".charCodeAt())
        {
            aux.pop()
            strings.push(aux.join(""))
            aux = []
        }
    })

    var i = 0;
    for (let i = 0, dataPointer = 0; i < json.functions.length; i++, dataPointer++)
    {
        let element = json.functions[i]

        if (element == 1)
        {
            console.log("resultado: " + dictFunc[json.functions[i]](strings[dataPointer]))
        }
        
        else if (element == 5)
        {
            if (parseInt(strings[dataPointer]) < parseInt(strings[dataPointer + 1]))
                dictFunc[json.functions[i + 1]](strings[dataPointer + 2])
        
            i += 1
            dataPointer += 2
        }
        else if (element == 0)
        {
            dictFunc[element](strings[dataPointer])
        }
    }
}) 