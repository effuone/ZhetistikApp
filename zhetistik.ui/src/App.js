import logo from './logo.svg';
import './App.css';

import {Home} from './Home';
import {Candidate} from './Candidate';
import {Navigation} from './Navigation';
import {Achievement} from './Achievement';
import {BrowserRouter, Route, Routes} from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
    <div className="App">
      <h3 className="m-3 d-flex justify-content-center">
        ZhetistikApp
      </h3> 
      <Navigation/> 
        <Routes> 
          <Route exact path="/" element={<Home/>} />
          <Route exact path="/candidate" element={<Candidate/>}/>
          <Route exact path="/achievement" element={<Achievement/>}/>
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
