class Index extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="index">
               <HomeTest />
            </div>
            );
    }
}

$(function () {
    ReactDOM.render(<Index />, document.getElementById("app"));
});