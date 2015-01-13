﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive.Disposables;
using System.Windows.Input;
using odm.infra;
namespace odm.ui.activities {
	using global::onvif.services;
	
	public partial class EngineControlsCreationView{
		
		#region Model definition
		
		public interface IModelAccessor{
			string name{get;set;}
			string token{get;set;}
			string vacToken{get;set;}
			
		}
		public class Model: IModelAccessor, INotifyPropertyChanged{
			
			public Model(){
			}
			

			public static Model Create(
				string name,
				string token,
				string vacToken
			){
				var _this = new Model();
				
				_this.origin.name = name;
				_this.origin.token = token;
				_this.origin.vacToken = vacToken;
				_this.RevertChanges();
				
				return _this;
			}
		
				private SimpleChangeTrackable<string> m_name;
				private SimpleChangeTrackable<string> m_token;
				private SimpleChangeTrackable<string> m_vacToken;

			private class OriginAccessor: IModelAccessor {
				private Model m_model;
				public OriginAccessor(Model model) {
					m_model = model;
				}
				string IModelAccessor.name {
					get {return m_model.m_name.origin;}
					set {m_model.m_name.origin = value;}
				}
				string IModelAccessor.token {
					get {return m_model.m_token.origin;}
					set {m_model.m_token.origin = value;}
				}
				string IModelAccessor.vacToken {
					get {return m_model.m_vacToken.origin;}
					set {m_model.m_vacToken.origin = value;}
				}
				
			}
			public event PropertyChangedEventHandler PropertyChanged;
			private void NotifyPropertyChanged(string propertyName){
				var prop_changed = this.PropertyChanged;
				if (prop_changed != null) {
					prop_changed(this, new PropertyChangedEventArgs(propertyName));
				}
			}
			
			public string name  {
				get {return m_name.current;}
				set {
					if(m_name.current != value) {
						m_name.current = value;
						NotifyPropertyChanged("name");
					}
				}
			}
			
			public string token  {
				get {return m_token.current;}
				set {
					if(m_token.current != value) {
						m_token.current = value;
						NotifyPropertyChanged("token");
					}
				}
			}
			
			public string vacToken  {
				get {return m_vacToken.current;}
				set {
					if(m_vacToken.current != value) {
						m_vacToken.current = value;
						NotifyPropertyChanged("vacToken");
					}
				}
			}
			
			public void AcceptChanges() {
				m_name.AcceptChanges();
				m_token.AcceptChanges();
				m_vacToken.AcceptChanges();
				
			}

			public void RevertChanges() {
				this.current.name= this.origin.name;
				this.current.token= this.origin.token;
				this.current.vacToken= this.origin.vacToken;
				
			}

			public bool isModified {
				get {
					if(m_name.isModified)return true;
					if(m_token.isModified)return true;
					if(m_vacToken.isModified)return true;
					
					return false;
				}
			}

			public IModelAccessor current {
				get {return this;}
				
			}

			public IModelAccessor origin {
				get {return new OriginAccessor(this);}
				
			}
		}
			
		#endregion
	
		#region Result definition
		public abstract class Result{
			private Result() { }
			
			public abstract T Handle<T>(
				
				Func<Model,T> finish,
				Func<Model,T> configureInputs,
				Func<Model,T> configureVac,
				Func<T> abort
			);
	
			public bool IsFinish(){
				return AsFinish() != null;
			}
			public virtual Finish AsFinish(){ return null; }
			public class Finish : Result {
				public Finish(Model config){
					
					this.config = config;
					
				}
				public Model config{ get; set; }
				public override Finish AsFinish(){ return this; }
				
				public override T Handle<T>(
				
					Func<Model,T> finish,
					Func<Model,T> configureInputs,
					Func<Model,T> configureVac,
					Func<T> abort
				){
					return finish(
						config
					);
				}
	
			}
			
			public bool IsConfigureInputs(){
				return AsConfigureInputs() != null;
			}
			public virtual ConfigureInputs AsConfigureInputs(){ return null; }
			public class ConfigureInputs : Result {
				public ConfigureInputs(Model config){
					
					this.config = config;
					
				}
				public Model config{ get; set; }
				public override ConfigureInputs AsConfigureInputs(){ return this; }
				
				public override T Handle<T>(
				
					Func<Model,T> finish,
					Func<Model,T> configureInputs,
					Func<Model,T> configureVac,
					Func<T> abort
				){
					return configureInputs(
						config
					);
				}
	
			}
			
			public bool IsConfigureVac(){
				return AsConfigureVac() != null;
			}
			public virtual ConfigureVac AsConfigureVac(){ return null; }
			public class ConfigureVac : Result {
				public ConfigureVac(Model config){
					
					this.config = config;
					
				}
				public Model config{ get; set; }
				public override ConfigureVac AsConfigureVac(){ return this; }
				
				public override T Handle<T>(
				
					Func<Model,T> finish,
					Func<Model,T> configureInputs,
					Func<Model,T> configureVac,
					Func<T> abort
				){
					return configureVac(
						config
					);
				}
	
			}
			
			public bool IsAbort(){
				return AsAbort() != null;
			}
			public virtual Abort AsAbort(){ return null; }
			public class Abort : Result {
				public Abort(){
					
				}
				
				public override Abort AsAbort(){ return this; }
				
				public override T Handle<T>(
				
					Func<Model,T> finish,
					Func<Model,T> configureInputs,
					Func<Model,T> configureVac,
					Func<T> abort
				){
					return abort(
						
					);
				}
	
			}
			
		}
		#endregion

		public ICommand FinishCommand{ get; private set; }
		public ICommand ConfigureInputsCommand{ get; private set; }
		public ICommand ConfigureVacCommand{ get; private set; }
		public ICommand AbortCommand{ get; private set; }
		
		IActivityContext<Result> activityContext = null;
		SingleAssignmentDisposable activityCancellationSubscription = new SingleAssignmentDisposable();
		bool activityCompleted = false;
		//activity has been completed
		event Action OnCompleted = null;
		//activity has been failed
		event Action<Exception> OnError = null;
		//activity has been completed successfully
		event Action<Result> OnSuccess = null;
		//activity has been canceled
		event Action OnCancelled = null;
		
		public EngineControlsCreationView(Model model, IActivityContext<Result> activityContext) {
			this.activityContext = activityContext;
			if(activityContext!=null){
				activityCancellationSubscription.Disposable = 
					activityContext.RegisterCancellationCallback(() => {
						EnsureAccess(() => {
							CompleteWith(() => {
								if(OnCancelled!=null){
									OnCancelled();
								}
							});
						});
					});
			}
			Init(model);
		}

		
		public void EnsureAccess(Action action){
			if(!CheckAccess()){
				Dispatcher.Invoke(action);
			}else{
				action();
			}
		}

		public void CompleteWith(Action cont){
			if(!activityCompleted){
				activityCompleted = true;
				cont();
				if(OnCompleted!=null){
					OnCompleted();
				}
				activityCancellationSubscription.Dispose();
			}
		}
		public void Success(Result result) {
			CompleteWith(() => {
				if(activityContext!=null){
					activityContext.Success(result);
				}
				if(OnSuccess!=null){
					OnSuccess(result);
				}
			});
		}
		public void Error(Exception error) {
			CompleteWith(() => {
				if(activityContext!=null){
					activityContext.Error(error);
				}
				if(OnError!=null){
					OnError(error);
				}
			});
		}
		public void Cancel() {
			CompleteWith(() => {
				if(activityContext!=null){
					activityContext.Cancel();
				}
				if(OnCancelled!=null){
					OnCancelled();
				}
			});
		}
		public void Success(Func<Result> resultFactory) {
			CompleteWith(() => {
				var result = resultFactory();
				if(activityContext!=null){
					activityContext.Success(result);
				}
				if(OnSuccess!=null){
					OnSuccess(result);
				}
			});
		}
		public void Error(Func<Exception> errorFactory) {
			CompleteWith(() => {
				var error = errorFactory();
				if(activityContext!=null){
					activityContext.Error(error);
				}
				if(OnError!=null){
					OnError(error);
				}
			});
		}
		public void Cancel(Action action) {
			CompleteWith(() => {
				action();
				if(activityContext!=null){
					activityContext.Cancel();
				}
				if(OnCancelled!=null){
					OnCancelled();
				}
			});
		}
		
	}
}
