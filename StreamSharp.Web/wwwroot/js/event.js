
console.log("caio")

const element = document.getElementById("home-listen-button");

element.addEventListener("click", function () {
    console.log("comecou")
    const evtSource = new EventSource("http://localhost:5073/api/product/streaming/caio");

    evtSource.onmessage = (event) => {
        console.log(event.data);
        var li = document.createElement("li");
        document.getElementById("stream").appendChild(li);
        li.textContent = `${event.data}`;
        DotNet.invokeMethodAsync('StreamSharp.Web', 'AddText', `${event.data}`)
    };
});