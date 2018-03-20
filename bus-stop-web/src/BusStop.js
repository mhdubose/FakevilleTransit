import React, {Component} from 'react';
import PropTypes from 'prop-types'
import './App.css';

class BusStop extends Component {
    constructor(props) {
        super(props);

        this.state = {
            routes: []
        };
        this.retrieveArrivals = this.retrieveArrivals.bind(this);
    }

    componentDidMount(){
        this.retrieveArrivals();
    }

    componentWillUnmount(){
        clearTimeout(this.state.timeout);
    }

    componentWillReceiveProps(nextProps){
        if(!nextProps.shouldPoll){
            clearTimeout(this.state.timeout);
        } else if (this.props.shouldPoll !== nextProps.shouldPoll){
            this.retrieveArrivals();
        }
    }

    retrieveArrivals() {
        fetch(`http://localhost:5000/api/busstop/${this.props.stopNumber}`)
            .then((response) =>
                response.json()
            ).then((data) => {
            let routes = data.busRoutes.map((route) => {
                let routeString = this.getRouteString(route);
                return <div key={route.id}>{routeString}</div>;
            },"");
            var timeout = null;
            if (this.props.shouldPoll) {
                timeout = setTimeout(this.retrieveArrivals, 10000);
            }
            this.setState({
                routes: routes,
                timeout: timeout
            })
        });
    }

    getRouteString(route) {
        return `Route ${route.id} in ${this.minutesUntilTime(route.arrivalTimes[0])} mins and ${this.minutesUntilTime(route.arrivalTimes[1])} mins`;
    }

    minutesUntilTime(time){
        let timeParts = time.split(':');
        let hours = parseInt(timeParts[0], 10);
        hours = hours === 0 ? 24 : hours;
        let current = new Date();
        return (hours - current.getHours()) * 60 + parseInt(timeParts[1],10) - current.getMinutes();
    }

    render() {
        return (
            <div className="Bus-stop">
                {this.state.routes}
            </div>
        )
    }
}

BusStop.propTypes = {
    stopNumber: PropTypes.number,
    shouldPoll: PropTypes.bool
}

export default BusStop;