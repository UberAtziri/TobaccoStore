
const Hello = () => {
    
  
    fetch('http://localhost:5001/api/tobacco')
    .then((response) => {
      console.log(response);
    });
  
    return (
      <div>
        <h1>QWERTY</h1>
      </div>
    );
  }
  
  ReactDOM.render(<Hello/>, document.getElementById('content'));