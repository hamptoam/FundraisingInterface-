import React, { Component } from 'react';
class Login extends Component {
    render() {
        return (
            <form className="form-horizontal">
                <div className="form-group">
                    <label className="col-md-2 control-label">Email</label>
                    <div className="col-md-10">
                        <input type="text" name="email" class="form-control" />
                    </div>
                </div>
                <div className="form-group">
                    <label className="col-md-2 control-label">Password</label>
                    <div className="col-md-10">
                        <input type="password" name="password" className="form-control" />
                    </div>
                </div>
                <div className="form-group">
                    <div className="col-md-offset-2 col-md-10">
                        <input type="submit" value="Log in" className="btn btn-default" />
                    </div>
                </div>
            </form>
        );
    }
}
export default Login;