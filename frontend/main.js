window.addEventListener('DOMContentLoaded', (event) => {
    getVisitCount();
});

const functionApi= 'https://gkt25sgaaa.execute-api.us-east-2.amazonaws.com/Prod/visitor/'; 

const getVisitCount = () => {
    let count = 0;
    fetch(functionApi).then(response => {
        return response.json()
    }).then(response => {
        console.log("Website called function API.");
        const count = response.count;
        document.getElementById('counter').innerText =count;
    }).catch(function(error){
        console.log(error)
    });
    return count;
}