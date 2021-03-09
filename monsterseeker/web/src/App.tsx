import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import Start from './pages/start';
import MonsterSeeker from './pages/monsterSeeker';

function App() {
  return (
    <Router>
      <Switch>
          <Route exact path="/" component={Start}/>
          <Route path="/MonsterSeeker" component={MonsterSeeker}/>
          <Route path="/easy"/>
          <Route path="/medium"/>
          <Route path="/hard"/>
      </Switch>
    </Router>
  );
};

export default App;
