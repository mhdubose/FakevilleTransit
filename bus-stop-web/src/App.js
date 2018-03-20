import React, {Component} from 'react';
import logo from './bus-logo.jpg';
import './App.css';
import {Button, ButtonToolbar, Tab, Tabs} from "react-bootstrap";
import BusStop from "./BusStop";

class App extends Component {
    constructor(props) {
        super(props);
        this.state = {
            pollingEnabled: true
        }
        this.togglePolling = this.togglePolling.bind(this);
    }

    togglePolling(e) {
        this.setState(prev => ({
            pollingEnabled: !prev.pollingEnabled
        }));
    }

    render() {
        return (
            <div className="App">
                <header className="App-header">
                    <img src={logo} className="App-logo" alt="logo"/>
                    <h1 className="App-title">Fakeville Transit</h1>
                </header>
                <div className="well Well-style">
                    <ButtonToolbar>
                        <Button bsStyle="primary" bsSize="large" block onClick={this.togglePolling}>
                            {this.state.pollingEnabled ? 'Stop Updating' : 'Start Updating'}
                        </Button>
                    </ButtonToolbar>
                </div>
                <Tabs defaultActiveKey={1} id="Bus Stops">
                    <Tab eventKey={1} title="Bus Stop 1">
                        <BusStop stopNumber={1} shouldPoll={this.state.pollingEnabled}/>
                    </Tab>
                    <Tab eventKey={2} title="Bus Stop 2">
                        <BusStop stopNumber={2} shouldPoll={this.state.pollingEnabled}/>
                    </Tab>
                </Tabs>
            </div>
        );
    }
}

export default App;
