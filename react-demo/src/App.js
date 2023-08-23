import React, { useState, useEffect } from "react";
import "./App.css";

const FloatInput = ({ label, value, onChange }) => {
  const handleInputChange = (event) => {
    const newValue = event.target.value;
    // Regular expression to match float numbers
    const floatValue = parseFloat(newValue);
    if (!isNaN(floatValue) || newValue === '') {
      onChange(newValue);
    }
  };

  return (
    <input
      type="text"
      value={value}
      onChange={handleInputChange}
      placeholder={`Enter Number ${label}`}
    />
  );
};

function App() {
  const [num1, setNum1] = useState("");
  const [num2, setNum2] = useState("");
  const [sum, setSum] = useState("");

  // Load saved sum from local storage on component mount
  useEffect(() => {
    const savedSum = localStorage.getItem("savedSum");
    if (savedSum) {
      //  setSum(savedSum);
    }
  }, []);

  const calculateSum = async () => {
    try {
      if (num1)
        var request = { "Number1": num1, "Number2": num2 };
      const response = await fetch('https://localhost:7153/Logic/add', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(request),
      });

      const result = await response.json();
      setSum(result.sum);
      setNum1("");
      setNum2("");
      // Save the sum to local storage
      localStorage.setItem("savedSum", result.sum.toString());

    } catch (error) {
      console.error('Error fetching data:', error);
    }
  };


  return (
    <div className="App">

      <h1>Sum Calculator</h1>

      <div>
        <FloatInput label="Number 1" value={num1} onChange={setNum1} />
      </div>

      <div>
        <FloatInput label="Number 2" value={num2} onChange={setNum2} />
      </div>

      <button onClick={calculateSum}>Calculate Sum</button>
      {
        sum && <p>Sum: {sum}</p>
      }

    </div>
  );
}

export default App;