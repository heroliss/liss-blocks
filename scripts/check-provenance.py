from pathlib import Path
import hashlib,json,subprocess
root=Path(__file__).resolve().parent.parent
manifest=json.loads((root/'legacy/manifest.json').read_text(encoding='utf-8'))
for item in manifest['files']:
    name='legacy/2015-original/'+item['path']
    assert hashlib.sha256((root/name).read_bytes()).hexdigest()==item['sha256'],name+' workspace'
    blob=subprocess.check_output(['git','show','HEAD:'+name],cwd=root)
    assert hashlib.sha256(blob).hexdigest()==item['sha256'],name+' git blob'
print(json.dumps({'passed':True,'files':len(manifest['files']),'workspaceAndGitBlobSha256':True}))
