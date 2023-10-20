class Tiozao
{
    sum = (a, b) => {return a + b}
    sub = (a, b) => {return a - b}
    div = (a, b) => {return a / b}
    mult = (a, b) => {return a * b}
    square = (b) => {return b * b}


    static command = {
        1 : console.log,
        2 : sum,
        3 : sub,
        4 : mult,
        5 : div,
        6 : square,
    }
    
    data = []

    save = (d) => {
        data.push(d)
    }


}