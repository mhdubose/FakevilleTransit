import React from 'react';
import ReactDOM from 'react-dom';
import BusStop from './BusStop';

it('renders without crashing', () => {
  const div = document.createElement('div');
  ReactDOM.render(<BusStop shouldPoll={true} stopNumber={1}/>, div);
  ReactDOM.unmountComponentAtNode(div);
});
